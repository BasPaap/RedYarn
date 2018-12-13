using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bas.RedYarn.WebApp.ViewModels
{
    public sealed class StorylineCharacterConnectionViewModel : ConnectionViewModel
    {
        public StorylineCharacterConnectionViewModel()
        { 
        }

        public StorylineCharacterConnectionViewModel(Func<(Guid, Guid)> getNodeIdsFunc = null)
            : base(getNodeIdsFunc)
        {
        }

        public StorylineCharacterConnectionViewModel(StorylineCharacterConnectionViewModel viewModel)
            : base(viewModel)
        {
        }
    }
}
