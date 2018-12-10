using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bas.RedYarn.WebApp.ViewModels
{
    public sealed class RelationshipViewModel : ConnectionViewModel
    {
        public bool IsDirectional { get; set; }

        public RelationshipViewModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RelationshipViewModel"/> class.
        /// </summary>
        /// <param name="model">The <see cref="Relationship"/> for which to create this viewmodel.</param>
        /// <param name="getIdForModelFunc">A function returning the Id for the provided model.</param>
        /// <param name="getNodeIdsFunc">A function returning the FromNode and ToNode Id's.</param>
        public RelationshipViewModel(Relationship model, Func<object, Guid> getIdForModelFunc = null, Func<(Guid, Guid)> getNodeIdsFunc = null)
            : base(getNodeIdsFunc)
        {
            if (getIdForModelFunc != null)
            {
                Id = getIdForModelFunc(model);
            }

            Name = model.Name;
            IsDirectional = model.IsDirectional;
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="viewModel">The viewmodel to copy.</param>
        public RelationshipViewModel(RelationshipViewModel viewModel)
            : base(viewModel)
        {
            Id = viewModel.Id;
            IsDirectional = viewModel.IsDirectional;
        }

        /// <summary>
        /// Returns the model this viewmodel represents.
        /// </summary>
        /// <returns>The model this viewmodel represents.</returns>
        /// <param name="getCharacterFunc">A function returning a character by one of the Ids in FromNodeId or ToNodeId. 
        /// Because the viewmodel has no idea what to do with the ids in FromNodeId and ToNodeId, the caller of this method
        /// will have to provide a method that takes an id and gets the right nodes for it. /></param>
        public Relationship ToModel(Func<Guid, Character> getCharacterFunc = null)
        {
            // Only set the properties we can set, so don't set shadow properties like the Id.
            var relationship = new Relationship()
            {
                Name = this.Name,
                IsDirectional = this.IsDirectional
            };

            if (getCharacterFunc != null)
            {
                relationship.FirstCharacter = getCharacterFunc(FromNodeId);
                relationship.SecondCharacter = getCharacterFunc(ToNodeId);
            }

            return relationship;
        }

        /// <summary>
        /// Update the provided model with the values in this viewmodel.
        /// </summary>
        /// <param name="model">The model to update.</param>
        /// <param name="getCharacterFunc">A function returning a character by one of the Ids in FromNodeId or ToNodeId.</param>
        public void UpdateModel(RedYarn.Relationship model, Func<Guid, Character> getCharacterFunc = null)
        {
            // Only set the properties we can set, so don't set shadow properties like the Id.
            model.Name = Name;
            model.IsDirectional = IsDirectional;

            if (getCharacterFunc != null)
            {
                model.FirstCharacter = getCharacterFunc(FromNodeId);
                model.SecondCharacter = getCharacterFunc(ToNodeId);
            }
        }
    }
}
