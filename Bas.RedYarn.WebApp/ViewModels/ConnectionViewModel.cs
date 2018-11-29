using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bas.RedYarn.WebApp.ViewModels
{
    public class ConnectionViewModel
    {
        public Guid FromNodeId { get; set; }
        public Guid ToNodeId { get; set; }

        public ConnectionViewModel()
        {
        }

        public ConnectionViewModel(ConnectionViewModel connectionViewModel)
        {
            FromNodeId = connectionViewModel.FromNodeId;
            ToNodeId = connectionViewModel.ToNodeId;
        }
    }
}
