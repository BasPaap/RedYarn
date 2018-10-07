using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bas.RedYarn.WebApp.Model
{
    public sealed class StorylineConnection
    {
        public Guid CharacterId { get; set; }
        public Guid StorylineId { get; set; }
    }
}
