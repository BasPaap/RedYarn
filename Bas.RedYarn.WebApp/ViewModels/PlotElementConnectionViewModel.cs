using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bas.RedYarn.WebApp.ViewModels
{
    public sealed class PlotElementConnectionViewModel
    {
        public Guid CharacterId { get; set; }
        public Guid PlotElementId { get; set; }
        public bool CharacterOwnsPlotElement { get; set; }

        public PlotElementConnectionViewModel()
        {
        }

        public PlotElementConnectionViewModel(PlotElementConnectionViewModel viewModel)
        {
            CharacterId = viewModel.CharacterId;
            PlotElementId = viewModel.PlotElementId;
            CharacterOwnsPlotElement = viewModel.CharacterOwnsPlotElement;
        }
    }
}
