using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bas.RedYarn.WebApp.ViewModels
{
    public sealed class PlotElementViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public PlotElementViewModel()
        {
        }

        public PlotElementViewModel(RedYarn.PlotElement plotElement)
        {
            Id = Guid.NewGuid();
            Name = plotElement.Name;
            Description = plotElement.Description;
        }

        public PlotElementViewModel(PlotElementViewModel viewModel)
        {
            Id = viewModel.Id;
            Name = viewModel.Name;
            Description = viewModel.Description;
        }

        public PlotElement ToModel()
        {
            return new PlotElement()
            {
                Name = Name,
                Description = Description
            };
        }
    }
}
