﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Bas.RedYarn
{
    /// <summary>
    /// Represents a relationship between various characters that is paired with a different (paired) relationship, for instance 
    /// a "father"/"son" relationship.
    /// </summary>
    sealed class PairedRelationship : Relationship
    {
        public Relationship OtherRelationship { get; set; }

        public override string ToString() => string.IsNullOrWhiteSpace(Name) ? nameof(PairedRelationship) : Name;
    }
}
