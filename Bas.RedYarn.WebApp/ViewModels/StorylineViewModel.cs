using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Bas.RedYarn.WebApp.ViewModels
{
    public sealed class StorylineViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public float YPosition { get; set; }
        public float XPosition { get; set; }

        public StorylineViewModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Storyline"/> class.
        /// </summary>
        /// <param name="storyline">The <see cref="Storyline"/> for which to create this viewmodel.</param>
        /// <param name="getIdForModelFunc">A function returning the Id for the provided model.</param>
        public StorylineViewModel(RedYarn.Storyline storyline, Func<object, Guid> getIdForModelFunc = null)
        {
            if (getIdForModelFunc != null)
            {
                Id = getIdForModelFunc(storyline);
            }
            Name = storyline.Name;
            Description = storyline.Description;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Storyline"/> class.
        /// </summary>
        /// <param name="storyline">The <see cref="Storyline"/> for which to create this viewmodel.</param>
        /// <param name="xPosition">The X position of the viewmodel in the diagram.</param>
        /// <param name="yPosition">The Y position of the viewmodel in the diagram.</param>
        /// <param name="getIdForModelFunc">A function returning the Id for the provided model.</param>
        public StorylineViewModel(Storyline storyline, float xPosition, float yPosition, Func<object, Guid> getIdForModelFunc = null)
            : this(storyline, getIdForModelFunc)
        {
            XPosition = xPosition;
            YPosition = yPosition;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StorylineViewModel"/> class.
        /// </summary>
        /// <param name="storyline">The <see cref="Storyline"/> for which to create this viewmodel.</param>
        /// <param name="storylineNode">The <see cref="StorylineNode"/> with which to create this viewmodel.</param>
        /// <param name="getIdForModelFunc">A function returning the Id for the provided model.</param>
        public StorylineViewModel(RedYarn.Storyline storyline, Database.StorylineNode storylineNode, Func<object, Guid> getIdForModelFunc = null)
            : this(storyline, storylineNode.XPosition, storylineNode.YPosition, getIdForModelFunc)
        {
        }


        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="viewModel">The viewmodel to copy.</param>
        public StorylineViewModel(StorylineViewModel viewModel)
        {
            Id = viewModel.Id;
            Name = viewModel.Name;
            Description = viewModel.Description;
            YPosition = viewModel.YPosition;
            XPosition = viewModel.XPosition;
        }

        /// <summary>
        /// Returns the model this viewmodel represents.
        /// </summary>
        /// <returns>The model this viewmodel represents.</returns>
        public Storyline ToModel()
        {
            // Only set the properties we can set, so don't set shadow properties like the Id.
            return new Storyline()
            {
                Name = Name,
                Description = Description
            };
        }

        /// <summary>
        /// Returns the Node entity this viewmodel represents (in other words, return StorylineNode, not Storyline).
        /// </summary>
        /// <returns>The node entity this viewmodel represents.</returns>
        public Database.StorylineNode ToNode()
        {
            return new Database.StorylineNode()
            {
                Storyline = ToModel(),
                Id = Id,
                XPosition = XPosition,
                YPosition = YPosition
            };
        }

        /// <summary>
        /// Update the provided model with the values in this viewmodel.
        /// </summary>
        /// <param name="model">The model to update.</param>
        public void UpdateModel(Storyline model)
        {
            // Only set the properties we can set, so don't set shadow properties like the Id.
            model.Name = Name;
            model.Description = Description;
        }

        /// <summary>
        /// Update the provided node entity with the values in this viewmodel.
        /// </summary>
        /// <param name="node">The node entity to update.</param>
        public void UpdateNode(Database.StorylineNode node)
        {
            node.XPosition = XPosition;
            node.YPosition = YPosition;
        }
    }
}