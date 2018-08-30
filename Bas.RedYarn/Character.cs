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
        public Collection<Author> Authors { get; } = new Collection<Author>();
        public Collection<Storyline> Storylines { get; } = new Collection<Storyline>();
        public Collection<Tag> Tags { get; } = new Collection<Tag>();
        public string ImagePath { get; set; }

        public Character()
        {
            Tags = new CoupledCollection<Tag, Character>(this, nameof(Character.Tags));
        }

        public override string ToString() => string.IsNullOrWhiteSpace(Name) ? nameof(Character) : Name;

        public void RelateTo(Character character, string relationDescription)
        {
            throw new NotImplementedException();
        }

        public void RelateTo(Character character, string relationDescription, string reverseRelationDescription)
        {
            throw new NotImplementedException();
        }

        public void UnrelateTo(Character character)
        {
            throw new NotImplementedException();
        }

        public void UnrelateTo(Character character, string relationDescription)
        {
            throw new NotImplementedException();
        }

        public ReadOnlyCollection<string> RelationsTo(Character character)
        {
            throw new NotImplementedException();
        }
    }
}
