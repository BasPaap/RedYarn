using System;
using System.Collections.Generic;
using System.Text;

namespace Bas.RedYarn
{
    internal sealed class OneWayRelationship : Relationship
    {
        public Character FromCharacter { get; set; }
        public Character ToCharacter { get; set; }
        public string Description { get; set; }

        public override string ToString() => $"{FromCharacter?.Name} {Description} {ToCharacter?.Name}";
    }
}
