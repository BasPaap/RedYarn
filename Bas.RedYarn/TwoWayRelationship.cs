using System;
using System.Collections.Generic;
using System.Text;

namespace Bas.RedYarn
{
    internal sealed class TwoWayRelationship : Relationship
    {
        public Character FirstCharacter { get; set; }
        public Character SecondCharacter { get; set; }
        public string DescriptionFromFirstToSecondCharacter { get; set; }
        public string DescriptionFromSecondToFirstCharacter { get; set; }

        public override string ToString() => $"{FirstCharacter?.Name} {DescriptionFromFirstToSecondCharacter}/{DescriptionFromSecondToFirstCharacter} {SecondCharacter?.Name}";
    }
}
