using System;
using System.Collections.ObjectModel;

namespace Bas.RedYarn.WebApp.ViewModel
{
    public sealed class Storyline
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public Storyline(RedYarn.Storyline storyline)
        {
            Id = Guid.NewGuid();
            Name = storyline.Name;
            Description = storyline.Description;
        }
    }
}