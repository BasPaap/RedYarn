using System;
using System.Collections.Generic;
using System.Text;

namespace Bas.RedYarn
{
    sealed class PairedRelationship : Relationship
    {
        public Relationship OtherRelationship { get; set; }

        public override string ToString() => string.IsNullOrWhiteSpace(Name) ? nameof(PairedRelationship) : Name;
    }
}
