using System;
using System.Collections.Generic;
using System.Text;

namespace Bas.RedYarn.WebApp.Database
{
    public interface INode
    {
        Guid Id { get; set; }
        float XPosition { get; set; }
        float YPosition { get; set; }                
    }
}
