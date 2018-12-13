using Bas.RedYarn.WebApp.Database;
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
        /// 
        /// Because a ConnectionViewModel is made to represent a connection between nodes, that means the nodes
        /// for this connection already exist somewhere and already have ids, otherwise there would be nothing to connect. 
        /// Therefore, the VM needs to be told how to find these ids. This can't be done by the model: it has, for instance, 
        /// perhaps not yet been saved to a database or XML file, and therefore may not yet have any relationships with those nodes.
        /// For this reason a method is provided as a parameter that simply returns the ids of both nodes when called. It is up to
        /// the caller of this constructor to determine how to obtain those ids.
        /// </summary>
        /// <param name="getNodeIdsFunc">A function returning the FromNode and ToNode Id's.</param>
        public ConnectionViewModel(Func<(Guid, Guid)> getNodeIdsFunc)
        {
            if (getNodeIdsFunc != null)
            {
                (var fromNodeId, var toNodeId) = getNodeIdsFunc();
                FromNodeId = fromNodeId;
                ToNodeId = toNodeId;
            }
        }

        /// <summary>
        /// Converts the ViewModel to a JoinTable.
        /// </summary>
        /// <typeparam name="FromType">The type of the JoinTable's LeftEntity</typeparam>
        /// <typeparam name="ToType">The type of the JoinTable's RightEntity</typeparam>
        /// <param name="getFromObjectFunc">A function that returns the From object for the model.</param>
        /// <param name="getToObjectFunc">A function that returns the To object for the model.</param>
        /// <returns>The JoinTable represented by this ViewModel</returns>
        public JoinTable<FromType, ToType> ToModel<FromType, ToType>(Func<Guid, FromType> getFromObjectFunc, 
                                                                     Func<Guid, ToType> getToObjectFunc) where FromType: class 
                                                                                                         where ToType : class
        {
            return new JoinTable<FromType, ToType>()
            {
                LeftEntity = getFromObjectFunc(this.FromNodeId),
                RightEntity = getToObjectFunc(this.ToNodeId)
            };
        }

        /// <summary>
        /// Updates <paramref name="model"/> with the values in this ViewModel.
        /// </summary>
        /// <typeparam name="FromType">The type of the JoinTable's LeftEntity</typeparam>
        /// <typeparam name="ToType">The type of the JoinTable's RightEntity</typeparam>
        /// <param name="model">The model to update</param>
        public void UpdateModel<FromType, ToType>(JoinTable<FromType, ToType> model) where FromType : class
                                                                                             where ToType : class
        {
            model.LeftEntityId = this.FromNodeId;
            model.RightEntityId = this.ToNodeId;
        }
    }
}