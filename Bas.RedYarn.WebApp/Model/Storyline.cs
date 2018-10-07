using System;
using System.Collections.ObjectModel;

namespace Bas.RedYarn.WebApp.Model
{
    public sealed class Storyline
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }        
    }
}