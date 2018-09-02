using System;
using System.Collections.Generic;
using System.Text;

namespace Bas.RedYarn
{
    abstract class Relationship
    {
        public Character FirstCharacter { get; set; }
        public Character SecondCharacter { get; set; }
    }
}
