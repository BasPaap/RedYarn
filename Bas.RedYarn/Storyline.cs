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

        public Collection<Character> Characters { get; } = new Collection<Character>();
        public Collection<Author> Authors { get; } = new Collection<Author>();

        public override string ToString() => $"Storyline {Name}";
    }
}
