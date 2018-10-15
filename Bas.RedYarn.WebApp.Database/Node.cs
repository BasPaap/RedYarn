using System;
using System.Collections.Generic;
using System.Text;

namespace Bas.RedYarn.WebApp.Database
{
    public abstract class Node
    {
        public Guid Id { get; set; }
        public float XPosition { get; set; }
        public float YPosition { get; set; }                
    }
}
