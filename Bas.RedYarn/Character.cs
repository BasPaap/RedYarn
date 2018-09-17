using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Bas.RedYarn.Extensions;
using System.Linq;
using System.Globalization;

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

        public void RelateTo(Character character, string relationshipDescription, string pairedRelationshipDescription = null)
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

            //var sanitizedRelationDescription = relationshipDescription.Sanitize();

            //if (sanitizedRelationDescription.Length == 0)
            //{
            //    throw new ArgumentException($"{nameof(relationshipDescription)} does not contain any valid characters.", nameof(relationshipDescription));
            //}

            //var existingRelationships = from r in this.relationships
            //                            where r.Characters.Contains(character) &&
            //                            r.Description.ToUpper(CultureInfo.InvariantCulture) == sanitizedRelationshipDescription.ToUpper(CultureInfo.InvariantCulture)
            //                            select r;

            //if (existingRelationships.Count() != 0)
            //{
            //    throw new ArgumentException("A relationship with that description already exists between these characters.", nameof(relationshipDescription));
            //}

            //if (isDirectional)
            //{
            //    var unidirectionalRelationship = new UnidirectionalRelationship()
            //    {
            //        FirstCharacter = this,
            //        SecondCharacter = character,
            //        Description = sanitizedRelationDescription
            //    };

            //    this.relationships.Add(unidirectionalRelationship);                
            //}
            //else
            //{
            //    var genericRelationship = new UnidirectionalRelationship()
            //    {
            //        FirstCharacter = this,
            //        SecondCharacter = character,
            //        Description = sanitizedRelationDescription
            //    };

            //    this.relationships.Add(genericRelationship);
            //    character.relationships.Add(genericRelationship);
            //}            

            throw new NotImplementedException();
        }

        //public void RelateTo(Character character, string relationshipDescription, string pairedRelationshipDescription)
        //{
        //    #region Preconditions
        //    if (character == null)
        //    {
        //        throw new ArgumentNullException(nameof(character));
        //    }

        //    if (character == this)
        //    {
        //        throw new ArgumentException("A character cannot be related to itself.", nameof(character));
        //    }

        //    if (relationshipDescription == null)
        //    {
        //        throw new ArgumentNullException(nameof(relationshipDescription));
        //    }
        //    else if (string.IsNullOrWhiteSpace(relationshipDescription))
        //    {
        //        throw new ArgumentException($"{nameof(relationshipDescription)} cannot be whitespace.", nameof(relationshipDescription));
        //    }

        //    if (pairedRelationshipDescription == null)
        //    {
        //        throw new ArgumentNullException(nameof(pairedRelationshipDescription));
        //    }
        //    else if (string.IsNullOrWhiteSpace(pairedRelationshipDescription))
        //    {
        //        throw new ArgumentException($"{nameof(pairedRelationshipDescription)} cannot be whitespace.", nameof(pairedRelationshipDescription));
        //    }

        //    if (relationshipDescription == pairedRelationshipDescription)
        //    {
        //        throw new NotSupportedException($"{nameof(relationshipDescription)} and {nameof(pairedRelationshipDescription)} cannot be the same.");
        //    }

        //    #endregion

        //    //var sanitizedRelationDescription = relationDescription.Sanitize();

        //    //if (sanitizedRelationDescription.Length == 0)
        //    //{
        //    //    throw new ArgumentException($"{nameof(relationDescription)} does not contain any valid characters.", nameof(relationDescription));
        //    //}

        //    //var sanitizedReverseRelationDescription = reverseRelationDescription.Sanitize();

        //    //if (sanitizedReverseRelationDescription.Length == 0)
        //    //{
        //    //    throw new ArgumentException($"{nameof(reverseRelationDescription)} does not contain any valid characters.", nameof(reverseRelationDescription));
        //    //}

        //    //var bidirectionalRelationship = new BidirectionalRelationship()
        //    //{
        //    //    FirstCharacter = this,
        //    //    SecondCharacter = character,
        //    //    DescriptionFromFirstToSecondCharacter = relationDescription,
        //    //    DescriptionFromSecondToFirstCharacter = reverseRelationDescription
        //    //};

        //    //this.relationships.Add(bidirectionalRelationship);
        //    //character.relationships.Add(bidirectionalRelationship);

        //    throw new NotImplementedException();
        //}
              
        public void UnrelateTo(Character character, string relationshipDescription = null, bool deletePaired = false)
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
                throw new ArgumentException($"{nameof(relationshipDescription)} cannot be whitespace.", nameof(relationshipDescription));
            }

            #endregion

            throw new NotImplementedException();
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

            //var relationshipsToCharacter = new List<string>();

            //foreach (var relationship in this.relationships)
            //{
            //    switch (relationship)
            //    {
            //        case BidirectionalRelationship bidirectionalRelationship:
            //            if (bidirectionalRelationship.FirstCharacter == this && bidirectionalRelationship.SecondCharacter == character)
            //            {
            //                relationshipsToCharacter.Add(bidirectionalRelationship.DescriptionFromFirstToSecondCharacter);
            //            }
            //            else if (bidirectionalRelationship.FirstCharacter == character && bidirectionalRelationship.SecondCharacter == this)
            //            {
            //                relationshipsToCharacter.Add(bidirectionalRelationship.DescriptionFromSecondToFirstCharacter);
            //            }
            //            break;
            //        case UnidirectionalRelationship unidirectionalRelationship:
            //            if (unidirectionalRelationship.FirstCharacter == this && unidirectionalRelationship.SecondCharacter == character)
            //            {
            //                relationshipsToCharacter.Add(unidirectionalRelationship.Description);
            //            }
            //            break;                    
            //        case null:
            //        default:
            //            break;
            //    }
            //}

            //return new ReadOnlyCollection<string>(relationshipsToCharacter);

            throw new NotImplementedException();
        }
    }
}
