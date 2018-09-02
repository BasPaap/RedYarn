using System;
using System.Collections.Generic;
using System.Text;

namespace Bas.RedYarn
{
    sealed class BidirectionalRelationship : Relationship
    {
        public string DescriptionFromFirstToSecondCharacter { get; set; }
        public string DescriptionFromSecondToFirstCharacter { get; set; }

        public override string ToString() => $"{FirstCharacter?.Name} {DescriptionFromFirstToSecondCharacter}/{DescriptionFromSecondToFirstCharacter} {SecondCharacter?.Name}";
    }
}
