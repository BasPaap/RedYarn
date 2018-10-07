using System;
using System.Collections.ObjectModel;
namespace Bas.RedYarn.WebApp.Model
{
    public sealed class Character
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Collection<string> Aliases { get; } = new Collection<string>();
        
    }
}