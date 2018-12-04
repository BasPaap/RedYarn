using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bas.RedYarn.WebApp.ViewModels
{
    public class ConnectionViewModel
    {
        public Guid Id { get; set; }
        public Guid FromNodeId { get; set; }
        public Guid ToNodeId { get; set; }
        public string Name { get; set; }

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
            Name = connectionViewModel.Name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectionViewModel" /> class.
        /// 
        /// Because a ConnectionViewModel is made to represent a connection between nodes, that means the nodes
        /// for this connection already exist somewhere and already have ids, otherwise there would be nothing to connect. 
        /// Therefore, the VM needs to be told how to find these ids. This can't be done by the model: it has, for instance, 
        /// perhaps not yet been saved to a database or XML file, and therefore may not yet have any relationships with those nodes.
        /// For this reason a method is provided as a parameter that simply returns the ids of both nodes when called. It is up to
        /// the caller of this constructor to determine how to obtain those ids.
        /// </summary>
        /// <param name="model">The RedYarn model for which to create this viewmodel.</param>
        /// <param name="getNodeIdsFunc">A function returning the FromNode and ToNode Id's.</param>

        public ConnectionViewModel(object model, Func<(Guid, Guid)> getNodeIdsFunc)
        {
            if (getNodeIdsFunc != null)
            {
                (var fromNodeId, var toNodeId) = getNodeIdsFunc();
                FromNodeId = fromNodeId;
                ToNodeId = toNodeId;
            }
        }
    }
}