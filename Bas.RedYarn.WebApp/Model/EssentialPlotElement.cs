using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bas.RedYarn.WebApp.Model
{
    public sealed class EssentialPlotElement
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public EssentialPlotElement(RedYarn.EssentialPlotElement essentialPlotElement)
        {
            Id = Guid.NewGuid();
            Name = essentialPlotElement.Name;
            Description = essentialPlotElement.Description;
        }
    }
}
