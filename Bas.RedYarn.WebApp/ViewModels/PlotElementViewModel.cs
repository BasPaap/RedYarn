using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Bas.RedYarn.WebApp.ViewModels
{
    public sealed class PlotElementViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public float YPosition { get; set; }
        public float XPosition { get; set; }

        public PlotElementViewModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlotElementViewModel"/> class.
        /// </summary>
        /// <param name="plotElement">The <see cref="PlotElement"/> for which to create this viewmodel.</param>
        /// <param name="getIdForModelFunc">A function returning the Id for the provided model.</param>
        public PlotElementViewModel(RedYarn.PlotElement plotElement, Func<object, Guid> getIdForModelFunc = null)
        {
            if (getIdForModelFunc != null)
            {
                Id = getIdForModelFunc(plotElement);
            }
            Name = plotElement.Name;
            Description = plotElement.Description;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlotElementViewModel"/> class.
        /// </summary>
        /// <param name="plotElement">The <see cref="PlotElement"/> for which to create this viewmodel.</param>
        /// <param name="xPosition">The X position of the viewmodel in the diagram.</param>
        /// <param name="yPosition">The Y position of the viewmodel in the diagram.</param>
        /// <param name="getIdForModelFunc">A function returning the Id for the provided model.</param>
        public PlotElementViewModel(PlotElement plotElement, float xPosition, float yPosition, Func<object, Guid> getIdForModelFunc = null)
            : this(plotElement, getIdForModelFunc)
        {
            XPosition = xPosition;
            YPosition = yPosition;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlotElementViewModel"/> class.
        /// </summary>
        /// <param name="plotElement">The <see cref="PlotElement"/> for which to create this viewmodel.</param>
        /// <param name="plotElementNode">The <see cref="PlotElementNode"/> with which to create this viewmodel.</param>
        /// <param name="getIdForModelFunc">A function returning the Id for the provided model.</param>
        public PlotElementViewModel(RedYarn.PlotElement plotElement, Database.PlotElementNode plotElementNode, Func<object, Guid> getIdForModelFunc = null)
            : this(plotElement, plotElementNode.XPosition, plotElementNode.YPosition, getIdForModelFunc)
        {
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="viewModel">The viewmodel to copy.</param>
        public PlotElementViewModel(PlotElementViewModel viewModel)
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
        public PlotElement ToModel()
        {
            // Only set the properties we can set, so don't set shadow properties like the Id.
            return new PlotElement()
            {
                Name = Name,
                Description = Description
            };
        }

        /// <summary>
        /// Update the provided model with the values in this viewmodel.
        /// </summary>
        /// <param name="model">The model to update.</param>
        public void UpdateModel(PlotElement model)
        {
            // Only set the properties we can set, so don't set shadow properties like the Id.
            model.Name = Name;
            model.Description = Description;
        }

        /// <summary>
        /// Returns the Node entity this viewmodel represents (in other words, return StorylineNode, not Storyline).
        /// </summary>
        /// <returns>The node entity this viewmodel represents.</returns>
        public Database.PlotElementNode ToNode()
        {
            return new Database.PlotElementNode()
            {
                PlotElement = ToModel(),
                Id = Id,
                XPosition = XPosition,
                YPosition = YPosition
            };
        }

        /// <summary>
        /// Update the provided node entity with the values in this viewmodel.
        /// </summary>
        /// <param name="node">The node entity to update.</param>
        public void UpdateNode(Database.PlotElementNode node)
        {
            node.XPosition = XPosition;
            node.YPosition = YPosition;
        }
    }
}