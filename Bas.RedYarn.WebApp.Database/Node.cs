using System;
using System.Collections.Generic;
using System.Text;

namespace Bas.RedYarn.WebApp.Database
{
    /// <summary>
    /// Abstract base class for Node types that will be shown in the diagram as nodes. Contains the various properties that need to be saved 
    /// which aren't in the Bas.RedYarn classes, such as X and Y position, and an ID.
    /// </summary>
    public abstract class Node
    {
        public Guid Id { get; set; }
        public float XPosition { get; set; }
        public float YPosition { get; set; }                
    }
}
