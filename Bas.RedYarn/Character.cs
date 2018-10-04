using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Bas.RedYarn.Extensions;
using System.Linq;
using System.Globalization;
using System.Diagnostics;

namespace Bas.RedYarn
{
    /// <summary>
    /// Represents a character as it occurs in a story, scenario etc. 
    /// </summary>
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
        public Collection<EssentialPlotElement> OwnedPlotElements { get; set; }
        public Collection<EssentialPlotElement> NeededPlotElements { get; set; }

        public Character()
        {
            Authors = new CoupledCollection<Author, Character>(this, nameof(Author.Characters));
            Storylines = new CoupledCollection<Storyline, Character>(this, nameof(Storyline.Characters));
            Tags = new CoupledCollection<Tag, Character>(this, nameof(Tag.Characters));
            OwnedPlotElements = new CoupledCollection<EssentialPlotElement, Character>(this, nameof(EssentialPlotElement.OwningCharacters));
            NeededPlotElements = new CoupledCollection<EssentialPlotElement, Character>(this, nameof(EssentialPlotElement.NeedingCharacters));
        }

        public override string ToString() => string.IsNullOrWhiteSpace(Name) ? nameof(Character) : Name;

        /// <summary>
        /// Relates the character and the provided character, using the specified name.
        /// </summary>
        /// <param name="character">The character to which this character is to be related.</param>
        /// <param name="relationshipName">Name of the relationship between the characters.</param>
        /// <param name="pairedRelationshipName">If not null, the name of a second relationship between the characters with which the new relationship is paired. <seealso cref="PairedRelationship"/></param>
        /// <exception cref="ArgumentNullException">Thrown when either <paramref name="character"/> or <paramref name="relationshipName"/> are null.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="character"/> equals <c>this</c>, or either <paramref name="relationshipName"/> or <paramref name="pairedRelationshipName"/> consist of whitespace.</exception>
        /// <exception cref="NotSupportedException">Thrown when <paramref name="relationshipName"/> equals <paramref name="pairedRelationshipName"/>.</exception>
        public void RelateTo(Character character, string relationshipName, string pairedRelationshipName = null)
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

            if (relationshipName == null)
            {
                throw new ArgumentNullException(nameof(relationshipName));
            }
            else if (string.IsNullOrWhiteSpace(relationshipName))
            {
                // If the relationship name is not null, but still only contains of whitespace, we can't do anything with it.
                throw new ArgumentException($"{nameof(relationshipName)} cannot be whitespace.", nameof(relationshipName));
            }

            if (pairedRelationshipName != null && string.IsNullOrWhiteSpace(pairedRelationshipName))
            {
                // If the relationship name is not null, but still only contains of whitespace, we can't do anything with it.
                throw new ArgumentException($"{nameof(pairedRelationshipName)} cannot be whitespace.", nameof(pairedRelationshipName));
            }

            if (relationshipName == pairedRelationshipName)
            {
                // If relationshipName and pairedRelationshipName are equal, we can't woth with this.
                throw new NotSupportedException($"{nameof(relationshipName)} and {nameof(pairedRelationshipName)} cannot be the same.");
            }

            #endregion

            // Getting cleaned up versions of the provided name.
            var sanitizedRelationshipName = relationshipName.Sanitize();
            var sanitizedPairedRelationshipName = pairedRelationshipName.Sanitize();

            var existingRelationships = from r in this.relationships
                                        where r.Characters.Contains(character) &&
                                        r.Name.ToUpper(CultureInfo.InvariantCulture) == sanitizedRelationshipName.ToUpper(CultureInfo.InvariantCulture) ||
                                        r.Name.ToUpper(CultureInfo.InvariantCulture) == sanitizedPairedRelationshipName.ToUpper(CultureInfo.InvariantCulture)
                                        select r;

            if (existingRelationships.Count() != 0)
            {
                // The character is not related to the provided culture, so we immediately return.
                return;
            }

            Relationship newRelationship = (pairedRelationshipName == null) ? new Relationship() : new PairedRelationship();

            newRelationship.Characters.Add(this);
            newRelationship.Characters.Add(character);
            newRelationship.Name = sanitizedRelationshipName;

            if (pairedRelationshipName != null)
            {
                var pairedRelationship = new PairedRelationship();
                pairedRelationship.Characters.Add(this);
                pairedRelationship.Characters.Add(character);
                pairedRelationship.Name = sanitizedPairedRelationshipName;
                pairedRelationship.OtherRelationship = newRelationship;

                Debug.Assert(newRelationship is PairedRelationship, "newRelationship should always be a PairedRelationship here.");
                (newRelationship as PairedRelationship).OtherRelationship = pairedRelationship;

                this.relationships.Add(pairedRelationship);
                character.relationships.Add(pairedRelationship);
            }

            this.relationships.Add(newRelationship);
            character.relationships.Add(newRelationship);
        }

        /// <summary>
        /// Removes the relationship between characters. If <paramref name="relationshipName"/> is given, only removes the relationship with that name, otherwise all
        /// relationships between this character and <paramref name="character"/> are removed.
        /// </summary>
        /// <param name="character">The character to which the relationship is to be removed.</param>
        /// <param name="relationshipName">The name of the relationship to remove. If null, all relationships between this character and <paramref name="character"/> are removed.</param>
        /// <param name="deletePaired">If true, the pairs in pairedrelationships are removed as well.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="character"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when trying to relate <c>this</c> to itself.</exception>
        public void UnrelateTo(Character character, string relationshipName = null, bool deletePaired = true)
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

            if (string.IsNullOrWhiteSpace(relationshipName) && relationshipName != null)
            {
                return;
            }

            #endregion

            var relationshipsToRemove = from r in this.relationships
                                        where r.Characters.Contains(character) &&
                                        r.Name == (relationshipName ?? r.Name)
                                        select r;

            if (relationshipsToRemove.Count() == 0)
            {
                return;
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
        }

        /// <summary>
        /// Returns true if this character has one or more relationships with <paramref name="character"/> or false if it does not. 
        /// If a <paramref name="relationshipName"/> is provided, return true if this character has a relationship by that name with <paramref name="character"/>.
        /// </summary>
        /// <param name="character">The character to test for a relationship with.</param>
        /// <param name="relationshipName">Optionally, the name of the relationship between the two characters.</param>
        /// <returns>A boolean value indicating wether this character has one or more relationships with <paramref name="character"/> (optionally by the name of <paramref name="relationshipName"/>).</returns>
        public bool IsRelatedTo(Character character, string relationshipName = null)
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

            if (string.IsNullOrWhiteSpace(relationshipName) && relationshipName != null)
            {
                // If the relationship name is not null, but still only contains of whitespace, we can't do anything with it.
                throw new ArgumentException($"{nameof(relationshipName)} cannot be whitespace.", nameof(relationshipName));
            }
            #endregion

            var relationships = from r in this.relationships
                                where r.Characters.Contains(character) &&
                                r.Name == (relationshipName ?? r.Name)
                                select r;

            return relationships.Count() >= 1;
        }

        /// <summary>
        /// Returns the names of relationships between <c>this</c> and <paramref name="character"/>.
        /// </summary>
        /// <param name="character">The character between which and <c>this</c> the relationship names are to be returned.</param>
        /// <returns>A ReadOnlyCollection containing the names of the relationships between <c>this</c> and <paramref name="character"/></returns>
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
                                                   select r.Name).ToList());
        }
    }
}
