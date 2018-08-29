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

        public override string ToString() => $"Character {Name}";

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

        public string RelationTo(Character character)
        {
            throw new NotImplementedException();
        }
    }
}
