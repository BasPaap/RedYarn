using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Bas.RedYarn
{
    public sealed class Storyline : INameable
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Collection<Character> Characters { get; }
        public Collection<Author> Authors { get; }

        public Storyline()
        {
            Characters = new CoupledCollection<Character, Storyline>(this, nameof(Character.Storylines));
            Authors = new CoupledCollection<Author, Storyline>(this, nameof(Author.Storylines));
        }

        public override string ToString() => string.IsNullOrWhiteSpace(Name) ? nameof(Storyline) : Name;
    }
}
