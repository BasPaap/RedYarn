﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Bas.RedYarn.Extensions;
using System.Linq;
using System.Globalization;
using System.Diagnostics;

namespace Bas.RedYarn
{
    public sealed class Character : INameable
    {
        private HashSet<Relationship> relationships = new HashSet<Relationship>();

        public string Name { get; set; }
        public Collection<string> Aliases { get; } = new Collection<string>();
        public string Description { get; set; }
        public Collection<Author> Authors { get; }
        public Collection<Storyline> Storylines { get; }
        public Collection<Tag> Tags { get; }
        public string ImagePath { get; set; }

        public Character()
        {
            Authors = new CoupledCollection<Author, Character>(this, nameof(Author.Characters));
            Storylines = new CoupledCollection<Storyline, Character>(this, nameof(Storyline.Characters));
            Tags = new CoupledCollection<Tag, Character>(this, nameof(Tag.Characters));
        }

        public override string ToString() => string.IsNullOrWhiteSpace(Name) ? nameof(Character) : Name;

        public bool RelateTo(Character character, string relationshipDescription, string pairedRelationshipDescription = null)
        {
            #region Preconditions
            if (character == null)
            {
                throw new ArgumentNullException(nameof(character));
            }

            if (character == this)
            {
                throw new ArgumentException("A character cannot be related to itself.", nameof(character));
            }

            if (relationshipDescription == null)
            {
                throw new ArgumentNullException(nameof(relationshipDescription));
            }
            else if (string.IsNullOrWhiteSpace(relationshipDescription))
            {
                throw new ArgumentException($"{nameof(relationshipDescription)} cannot be whitespace.", nameof(relationshipDescription));
            }

            if (pairedRelationshipDescription != null && string.IsNullOrWhiteSpace(pairedRelationshipDescription))
            {
                throw new ArgumentException($"{nameof(pairedRelationshipDescription)} cannot be whitespace.", nameof(pairedRelationshipDescription));
            }

            if (relationshipDescription == pairedRelationshipDescription)
            {
                throw new NotSupportedException($"{nameof(relationshipDescription)} and {nameof(pairedRelationshipDescription)} cannot be the same.");
            }

            #endregion

            var sanitizedRelationshipDescription = relationshipDescription.Sanitize();
            var sanitizedPairedRelationshipDescription = pairedRelationshipDescription.Sanitize();

            var existingRelationships = from r in this.relationships
                                        where r.Characters.Contains(character) &&
                                        r.Description.ToUpper(CultureInfo.InvariantCulture) == sanitizedRelationshipDescription.ToUpper(CultureInfo.InvariantCulture) ||
                                        r.Description.ToUpper(CultureInfo.InvariantCulture) == sanitizedPairedRelationshipDescription.ToUpper(CultureInfo.InvariantCulture)
                                        select r;

            if (existingRelationships.Count() != 0)
            {
                return false;
            }

            Relationship newRelationship = (pairedRelationshipDescription == null) ? new Relationship() : new PairedRelationship();

            newRelationship.Characters.Add(this);
            newRelationship.Characters.Add(character);
            newRelationship.Description = sanitizedRelationshipDescription;

            if (pairedRelationshipDescription != null)
            {
                var pairedRelationship = new PairedRelationship();
                pairedRelationship.Characters.Add(this);
                pairedRelationship.Characters.Add(character);
                pairedRelationship.Description = sanitizedPairedRelationshipDescription;
                pairedRelationship.OtherRelationship = newRelationship;

                Debug.Assert(newRelationship is PairedRelationship, "newRelationship should always be a PairedRelationship here.");
                (newRelationship as PairedRelationship).OtherRelationship = pairedRelationship;
                
                this.relationships.Add(pairedRelationship);
                character.relationships.Add(pairedRelationship);
            }

            this.relationships.Add(newRelationship);
            character.relationships.Add(newRelationship);

            return true;
        }

        public bool UnrelateTo(Character character, string relationshipDescription = null, bool deletePaired = false)
        {
            #region Preconditions
            if (character == null)
            {
                throw new ArgumentNullException(nameof(character));
            }

            if (character == this)
            {
                throw new ArgumentException("A character cannot be related to itself.", nameof(character));
            }

            if (string.IsNullOrWhiteSpace(relationshipDescription) && relationshipDescription != null)
            {
                return false;
            }

            #endregion

            var relationshipsToRemove = from r in this.relationships
                                        where r.Characters.Contains(character) &&
                                        r.Description == (relationshipDescription ?? r.Description)
                                        select r;

            if (relationshipsToRemove.Count() == 0)
            {
                return false;
            }

            foreach (var relationshipToRemove in relationshipsToRemove.ToList())
            {
                this.relationships.Remove(relationshipToRemove);
                character.relationships.Remove(relationshipToRemove);

                if (deletePaired)
                {
                    var otherRelationship = (relationshipToRemove as PairedRelationship)?.OtherRelationship;
                    
                    if (otherRelationship != null)
                    {
                        this.relationships.Remove(otherRelationship);
                        character.relationships.Remove(otherRelationship);
                    }
                }
            }

            return true;
        }

        public ReadOnlyCollection<string> GetRelationshipsTo(Character character)
        {
            #region Preconditions
            if (character == null)
            {
                throw new ArgumentNullException(nameof(character));
            }

            if (character == this)
            {
                throw new ArgumentException("A character cannot be related to itself.", nameof(character));
            }
            #endregion

            return new ReadOnlyCollection<string>((from r in this.relationships
                                                   where r.Characters.Contains(this) &&
                                                         r.Characters.Contains(character)
                                                   select r.Description).ToList());
        }
    }
}
