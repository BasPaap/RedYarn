using System;
using System.Collections.ObjectModel;

namespace Bas.RedYarn
{
    public sealed class Tag : INameable
    {
        public string Name { get; set; }
        public Collection<Character> Characters { get; }

        public Tag()
        {
            Characters = new CoupledCollection<Character, Tag>(this, nameof(Character.Tags));
        }

        public override string ToString() => string.IsNullOrWhiteSpace(Name) ? nameof(Tag) : Name;
    }
}