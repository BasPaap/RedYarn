using System;
using System.Collections.Generic;
using System.Text;

namespace Bas.RedYarn
{
    sealed class NonDirectionalRelationship : IRelationship
    {
        public Character FirstCharacter { get; set; }
        public Character SecondCharacter { get; set; }
        public bool IsDirectional { get; } = false;
        public string Name { get; set; }

        public override string ToString() => string.IsNullOrWhiteSpace(Name) ? nameof(NonDirectionalRelationship) : Name;

        internal NonDirectionalRelationship(Character firstCharacter, Character secondCharacter, string name)
        {
            FirstCharacter = firstCharacter;
            SecondCharacter = secondCharacter;
            Name = name;
        }
    }
}
