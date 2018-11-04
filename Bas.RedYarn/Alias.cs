using System;
using System.Collections.Generic;
using System.Text;

namespace Bas.RedYarn
{
    public sealed class Alias : INameable
    {
        public string Name { get; set; }
        public override string ToString() => string.IsNullOrWhiteSpace(Name) ? nameof(Alias) : Name;
    }
}
