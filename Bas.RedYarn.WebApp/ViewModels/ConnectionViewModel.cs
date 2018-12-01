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

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="connectionViewModel">The viewmodel to copy.</param
        public ConnectionViewModel(ConnectionViewModel connectionViewModel)
        {
            FromNodeId = connectionViewModel.FromNodeId;
            ToNodeId = connectionViewModel.ToNodeId;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectionViewModel" /> class.
        /// </summary>
        /// <param name="model">The RedYarn model for which to create this viewmodel.</param>
        /// <param name="getConnectionIdsForModelFunc">A function returning the FromNode and ToNode Id's for the provided model.</param>
        public ConnectionViewModel(object model, Func<object, (Guid, Guid)> getConnectionIdsForModelFunc)
        {
            if (getConnectionIdsForModelFunc != null)
            {
                (var fromNodeId, var toNodeId) = getConnectionIdsForModelFunc(model);
                FromNodeId = fromNodeId;
                ToNodeId = toNodeId;
            }
        }
    }
}
