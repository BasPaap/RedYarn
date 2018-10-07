﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bas.RedYarn.WebApp.Model
{
    public sealed class Relationship
    {
        public Guid FromCharacterId { get; set; }
        public Guid ToCharacterId { get; set; }
        public string Name { get; set; }
    }
}
