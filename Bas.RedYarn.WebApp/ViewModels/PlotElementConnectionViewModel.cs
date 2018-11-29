using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bas.RedYarn.WebApp.ViewModels
{
    public sealed class PlotElementConnectionViewModel : ConnectionViewModel
    {
        public bool CharacterOwnsPlotElement { get; set; }

        public PlotElementConnectionViewModel()
        {
        }

        public PlotElementConnectionViewModel(PlotElementConnectionViewModel viewModel)
            : base(viewModel)
        {
            CharacterOwnsPlotElement = viewModel.CharacterOwnsPlotElement;
        }
    }
}
