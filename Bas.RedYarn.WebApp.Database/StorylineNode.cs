using System;
using System.Collections.Generic;
using System.Text;

namespace Bas.RedYarn.WebApp.Database
{
    public sealed class StorylineNode : INode
    {
        public Guid Id { get; set; }
        public float XPosition { get; set; }
        public float YPosition { get; set; }

        public Storyline Storyline { get; set; }
    }
}
