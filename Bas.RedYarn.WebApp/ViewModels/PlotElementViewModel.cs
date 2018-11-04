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
            Id = getIdForModelFunc(plotElement);
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

        public PlotElementViewModel(PlotElementViewModel viewModel)
        {
            Id = viewModel.Id;
            Name = viewModel.Name;
            Description = viewModel.Description;
            YPosition = viewModel.YPosition;
            XPosition = viewModel.XPosition;
        }

        public PlotElement ToModel()
        {
            return new PlotElement()
            {
                Name = Name,
                Description = Description
            };
        }

        public void UpdateModel(PlotElement model)
        {
            model.Name = Name;
            model.Description = Description;
        }

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

        public void UpdateNode(Database.PlotElementNode node)
        {
            node.XPosition = XPosition;
            node.YPosition = YPosition;
        }
    }
}