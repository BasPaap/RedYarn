using System;
using System.Collections.ObjectModel;

namespace Bas.RedYarn
{
    public sealed class Author : INameable
    {
        public string Name { get; set; }
        public Collection<Character> Characters { get; } = new Collection<Character>();
        public Collection<Storyline> Storylines { get; } = new Collection<Storyline>();

        public override string ToString() => string.IsNullOrWhiteSpace(Name) ? nameof(Author) : Name;
    }
}