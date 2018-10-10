using System;
using System.Collections.Generic;
using System.Text;

namespace Bas.RedYarn
{
    /// <summary>
    /// Defines a property that supports giving an object a name.
    /// </summary>
    public interface INameable
    {
        string Name { get; }
    }
}
