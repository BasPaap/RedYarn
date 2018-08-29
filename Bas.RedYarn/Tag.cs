using System;
using System.Collections.ObjectModel;

namespace Bas.RedYarn
{
    public sealed class Tag : INameable
    {
        public string Name { get; set; }
        public Collection<Character> Characters { get; } = new Collection<Character>();

        //public override string ToString() => $"Tag {Name}";
    }
}