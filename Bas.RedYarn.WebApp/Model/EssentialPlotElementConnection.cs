using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bas.RedYarn.WebApp.Model
{
    public sealed class EssentialPlotElementConnection
    {
        public Guid CharacterId { get; set; }
        public Guid EssentialPlotElementId { get; set; }
        public bool CharacterOwnsPlotElement { get; set; }
    }
}
