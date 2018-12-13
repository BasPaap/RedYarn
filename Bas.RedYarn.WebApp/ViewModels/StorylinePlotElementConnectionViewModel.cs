using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bas.RedYarn.WebApp.ViewModels
{
    public sealed class StorylinePlotElementConnectionViewModel : ConnectionViewModel
    {
        public StorylinePlotElementConnectionViewModel()
        {
        }

        public StorylinePlotElementConnectionViewModel(Func<(Guid, Guid)> getNodeIdsFunc = null)
            : base(getNodeIdsFunc)
        {
        }

        public StorylinePlotElementConnectionViewModel(StorylinePlotElementConnectionViewModel viewModel)
            : base(viewModel)
        {
        }
    }
}
