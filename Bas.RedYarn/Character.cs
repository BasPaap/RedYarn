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
        private HashSet<IRelationship> relationships = new HashSet<IRelationship>();

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
        /// <param name="isDirectional">Specifies wether the relationship goes from this character to <paramref name="character"/>, or is simply between the two characters.</param>
        /// <exception cref="ArgumentNullException">Thrown when either <paramref name="character"/> or <paramref name="relationshipName"/> are null.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="character"/> equals <c>this</c>, or <paramref name="relationshipName"/> consist of whitespace.</exception>
        public void RelateTo(Character character, string relationshipName, bool isDirectional = false)
        {
            RelateTo(character, relationshipName, isDirectional, null);
        }

        /// <summary>
        /// Relates the character and the provided character, using the specified name and a name for the reverse, paired relationship.
        /// </summary>
        /// <param name="character">The character to which this character is to be related.</param>
        /// <param name="relationshipName">Name of the relationship between the characters.</param>
        /// <param name="pairedRelationshipName">If not null, the name of a second relationship between the characters with which the new relationship is paired. <seealso cref="PairedRelationship"/></param>
        /// <exception cref="ArgumentNullException">Thrown when either <paramref name="character"/> or <paramref name="relationshipName"/> are null.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="character"/> equals <c>this</c>, or either <paramref name="relationshipName"/> or <paramref name="pairedRelationshipName"/> consist of whitespace.</exception>
        /// <exception cref="NotSupportedException">Thrown when <paramref name="relationshipName"/> equals <paramref name="pairedRelationshipName"/>.</exception>
        public void RelateTo(Character character, string relationShipName, string pairedRelationshipName)
        {
            RelateTo(character, relationShipName, true, pairedRelationshipName);
        }

        /// <summary>
        /// Relates the character and the provided character, using the specified name.
        /// </summary>
        /// <param name="character">The character to which this character is to be related.</param>
        /// <param name="relationshipName">Name of the relationship between the characters.</param>
        /// <param name="isDirectional">Specifies wether the relationship goes from this character to <paramref name="character"/>, or is simply between the two characters.</param>
        /// <param name="pairedRelationshipName">If not null, the name of a second relationship between the characters with which the new relationship is paired. <seealso cref="PairedRelationship"/></param>
        /// <exception cref="ArgumentNullException">Thrown when either <paramref name="character"/> or <paramref name="relationshipName"/> are null.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="character"/> equals <c>this</c>, or either <paramref name="relationshipName"/> or <paramref name="pairedRelationshipName"/> consist of whitespace.</exception>
        /// <exception cref="NotSupportedException">Thrown when <paramref name="relationshipName"/> equals <paramref name="pairedRelationshipName"/>.</exception>
        private void RelateTo(Character character, string relationshipName, bool isDirectional = false, string pairedRelationshipName = null)
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

            Debug.Assert(isDirectional == true || 
                         (isDirectional == false && pairedRelationshipName == null), 
                         "A nondirectional relationship cannot be paired. When supplying a pairedRelationshipName, isDirectional cannot be false.");
                       
            // Getting cleaned up versions of the provided name.
            var sanitizedRelationshipName = relationshipName.Sanitize();
            var sanitizedPairedRelationshipName = pairedRelationshipName.Sanitize();

            var existingRelationships = from r in this.relationships
                                        where (r.FirstCharacter == character || r.SecondCharacter == character) &&
                                        r.Name.ToUpper(CultureInfo.InvariantCulture) == sanitizedRelationshipName.ToUpper(CultureInfo.InvariantCulture) ||
                                        r.Name.ToUpper(CultureInfo.InvariantCulture) == sanitizedPairedRelationshipName.ToUpper(CultureInfo.InvariantCulture)
                                        select r;

            if (existingRelationships.Count() != 0)
            {
                // The character is already related to the other character by that name.
                return;
            }

            IRelationship newRelationship;

            if (!isDirectional)
            {
                newRelationship = new NonDirectionalRelationship();
            }
            else
            {
                newRelationship = (pairedRelationshipName == null) ? new DirectionalRelationship() : new PairedRelationship();
            }

            newRelationship.FirstCharacter = this;
            newRelationship.SecondCharacter = character;
            newRelationship.Name = sanitizedRelationshipName;

            if (pairedRelationshipName != null)
            {
                Debug.Assert(newRelationship is PairedRelationship, "If pairedRelationship name is set, newRelationship should be Paired.");
                var newPairedRelationship = newRelationship as PairedRelationship;

                var otherPairedRelationship = new PairedRelationship
                {
                    FirstCharacter = character,
                    SecondCharacter = this,
                    Name = sanitizedPairedRelationshipName,
                    OtherRelationship = newPairedRelationship
                };
                                
                newPairedRelationship.OtherRelationship = otherPairedRelationship;

                // Add the other relationship to both this character and the other character.
                this.relationships.Add(otherPairedRelationship);
                character.relationships.Add(otherPairedRelationship);
            }

            // Add the relationship to both this character and the other character.
            this.relationships.Add(newRelationship);
            character.relationships.Add(newRelationship);
        }

        /// <summary>
        /// Removes the relationship between characters. If <paramref name="relationshipName"/> is given, only removes the relationship with that name, otherwise all
        /// relationships between this character and <paramref name="character"/> are removed.
        /// </summary>
        /// <param name="character">The character to which the relationship is to be removed.</param>
        /// <param name="relationshipName">The name of the relationship to remove. If null, all relationships between this character and <paramref name="character"/> are removed.</param>
        /// <param name="deletePaired">If true, the relationship in pairedrelationship is removed as well.</param>
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
                                        where (r.FirstCharacter == character || r.SecondCharacter == character) &&
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

                var otherRelationship = (relationshipToRemove as PairedRelationship)?.OtherRelationship;

                if (otherRelationship != null)
                {
                    // Remove the paired relationship. If the caller doesn't want the paired relationship deleted, convert it to a DirectionalRelationsip.
                    
                    if (!deletePaired)
                    {
                        var directionalRelationship = new DirectionalRelationship()
                        {
                            FirstCharacter = otherRelationship.FirstCharacter,
                            SecondCharacter = otherRelationship.SecondCharacter,
                            Name = otherRelationship.Name
                        };

                        this.relationships.Add(directionalRelationship);
                        character.relationships.Add(directionalRelationship);                        
                    }

                    this.relationships.Remove(otherRelationship);
                    character.relationships.Remove(otherRelationship);
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
                                where (r.FirstCharacter == character || r.SecondCharacter == character) &&
                                r.Name == (relationshipName ?? r.Name)
                                select r;

            return relationships.Count() >= 1;
        }

        /// <summary>
        /// Returns information about the relationships between <c>this</c> and <paramref name="character"/>.
        /// </summary>
        /// <param name="character">The character between which and <c>this</c> the relationship names are to be returned.</param>
        /// <returns>A ReadOnlyCollection containing RelationshipInfo objects describing the relationships between <c>this</c> and <paramref name="character"/></returns>
        public ReadOnlyCollection<RelationshipInfo> GetRelationshipsTo(Character character)
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

            var allRelationships = from r in this.relationships
                                   where (r is NonDirectionalRelationship && (r.FirstCharacter == character || r.SecondCharacter == character)) ||
                                         (r is DirectionalRelationship && !(r is PairedRelationship) && (r.FirstCharacter == character || r.SecondCharacter == character)) ||
                                         (r is PairedRelationship && r.FirstCharacter == this && r.SecondCharacter == character)
                                   select GetRelationshipInfo(r);
                               
            return new ReadOnlyCollection<RelationshipInfo>(allRelationships.ToList());
        }

        private RelationshipInfo GetRelationshipInfo(IRelationship relationship)
        {
            var relationshipInfo = new RelationshipInfo() { Name = relationship.Name };

            switch (relationship)
            {
                case NonDirectionalRelationship nonDirectionalRelationship:
                    relationshipInfo.Type = RelationshipType.NonDirectional;
                    break;
                case PairedRelationship pairedRelationship:
                case DirectionalRelationship directionalRelationship:
                    relationshipInfo.Type = relationship.FirstCharacter == this ? RelationshipType.Forward :
                                                                                  RelationshipType.Reverse;
                    break;                
                default:
                    return null;
            }

            return relationshipInfo;
        }
    }
}
