using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Bas.RedYarn
{
    public sealed class Character : INameable
    {
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

        public void RelateTo(Character character, string relationDescription)
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

            if (relationDescription == null)
            {
                throw new ArgumentNullException(nameof(relationDescription));
            }

            if (relationDescription == string.Empty)
            {
                throw new ArgumentException($"{nameof(relationDescription)} cannot be empty.", nameof(relationDescription));
            }

            #endregion

            throw new NotImplementedException();
        }

        public void RelateTo(Character character, string relationDescription, string reverseRelationDescription)
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

            if (relationDescription == null)
            {
                throw new ArgumentNullException(nameof(relationDescription));
            }

            if (reverseRelationDescription == null)
            {
                throw new ArgumentNullException(nameof(reverseRelationDescription));
            }

            if (relationDescription == string.Empty)
            {
                throw new ArgumentException($"{nameof(relationDescription)} cannot be empty.", nameof(relationDescription));
            }

            if (reverseRelationDescription == string.Empty)
            {
                throw new ArgumentException($"{nameof(reverseRelationDescription)} cannot be empty.", nameof(reverseRelationDescription));
            } 
            #endregion

            throw new NotImplementedException();
        }

        public void UnrelateTo(Character character)
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

            throw new NotImplementedException();
        }

        public void UnrelateTo(Character character, string relationDescription)
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

            if (relationDescription == null)
            {
                throw new ArgumentNullException(nameof(relationDescription));
            }

            if (relationDescription == string.Empty)
            {
                throw new ArgumentException($"{nameof(relationDescription)} cannot be empty.", nameof(relationDescription));
            }

            #endregion

            throw new NotImplementedException();
        }

        public ReadOnlyCollection<string> RelationsTo(Character character)
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
            throw new NotImplementedException();
        }
    }
}
