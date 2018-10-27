using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bas.RedYarn.WebApp.ViewModels
{
    public sealed class StorylineConnectionViewModel
    {
        public Guid ConnectionId { get; set; }
        public Guid StorylineId { get; set; }

        public StorylineConnectionViewModel()
        {
        }

        public StorylineConnectionViewModel(StorylineConnectionViewModel viewModel)
        {
            ConnectionId = viewModel.ConnectionId;
            StorylineId = viewModel.StorylineId;
        }
    }

}
