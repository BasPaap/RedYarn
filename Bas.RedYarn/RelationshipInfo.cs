﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Bas.RedYarn
{
    public sealed class RelationshipInfo : INameable
    {
        public string Name { get; set; }
        public RelationshipType Type { get; set; }
    }
}
