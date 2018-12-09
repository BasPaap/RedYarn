using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bas.RedYarn.WebApp.ViewModels
{
    public sealed class CharacterPlotElementConnectionViewModel : ConnectionViewModel
    {
        public bool CharacterOwnsPlotElement { get; set; }

        public CharacterPlotElementConnectionViewModel()
        {
        }

        public CharacterPlotElementConnectionViewModel(CharacterPlotElementConnectionViewModel viewModel)
            : base(viewModel)
        {
            CharacterOwnsPlotElement = viewModel.CharacterOwnsPlotElement;
        }

        public CharacterPlotElementConnectionViewModel(Func<(Guid, Guid)> getNodeIdsFunc)
            : base(getNodeIdsFunc)
        {
        }
    }
}
