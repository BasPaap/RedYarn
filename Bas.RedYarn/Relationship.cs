using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Bas.RedYarn
{
    /// <summary>
    /// Represents a relationship between several characters.
    /// </summary>
    class Relationship : INameable
    {
        public Character FirstCharacter { get; set; }
        public Character SecondCharacter { get; set; }

        public string Name { get; set; }

        public override string ToString() => string.IsNullOrWhiteSpace(Name) ? nameof(Relationship) : Name;
    }
}
