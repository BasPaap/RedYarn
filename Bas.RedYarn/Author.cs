using System;
using System.Collections.ObjectModel;

namespace Bas.RedYarn
{
    public sealed class Author : INameable
    {
        public string Name { get; set; }
        public Collection<Character> Characters { get; }
        public Collection<Storyline> Storylines { get; }

        public Author()
        {
            Characters = new CoupledCollection<Character, Author>(this, nameof(Character.Authors));
            Storylines = new CoupledCollection<Storyline, Author>(this, nameof(Storyline.Authors));
        }

        public override string ToString() => string.IsNullOrWhiteSpace(Name) ? nameof(Author) : Name;
    }
}