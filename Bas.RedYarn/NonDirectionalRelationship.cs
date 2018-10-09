using System;
using System.Collections.Generic;
using System.Text;

namespace Bas.RedYarn
{
    sealed class NonDirectionalRelationship : IRelationship
    {
        public Character FirstCharacter { get; set; }
        public Character SecondCharacter { get; set; }

        public string Name { get; set; }

        public override string ToString() => string.IsNullOrWhiteSpace(Name) ? nameof(NonDirectionalRelationship) : Name;
    }
}
