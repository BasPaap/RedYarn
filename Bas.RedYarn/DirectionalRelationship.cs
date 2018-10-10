using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Bas.RedYarn
{
    /// <summary>
    /// Represents a relationship between several characters.
    /// </summary>
    class DirectionalRelationship : IRelationship
    {
        public Character FirstCharacter { get; internal set; }
        public Character SecondCharacter { get; internal set; }
        public bool IsDirectional { get; } = true;
        public string Name { get; internal set; }

        public override string ToString() => string.IsNullOrWhiteSpace(Name) ? nameof(DirectionalRelationship) : Name;

        internal DirectionalRelationship(Character firstCharacter, Character secondCharacter, string name)
        {
            FirstCharacter = firstCharacter;
            SecondCharacter = secondCharacter;
            Name = name;
        }
    }
}
