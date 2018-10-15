using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bas.RedYarn.WebApp.ViewModel
{
    public sealed class RelationshipViewModel
    {
        public Guid FromCharacterId { get; set; }
        public Guid ToCharacterId { get; set; }
        public string Name { get; set; }
        public bool IsDirectional { get; set; }
    }
}
