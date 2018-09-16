using System;
using System.Collections.Generic;
using System.Text;

namespace Bas.RedYarn
{
    sealed class PairedRelationship : Relationship
    {
        public Relationship OtherRelationship { get; set; }
    }
}
