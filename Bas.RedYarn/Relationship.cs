using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Bas.RedYarn
{
    class Relationship
    {
        public Collection<Character> Characters { get; set; } = new Collection<Character>();
        public string Description { get; set; }
    }
}
