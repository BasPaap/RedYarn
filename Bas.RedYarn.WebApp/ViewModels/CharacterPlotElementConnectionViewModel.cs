using Bas.RedYarn.WebApp.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bas.RedYarn.WebApp.ViewModels
{
    public sealed class CharacterPlotElementConnectionViewModel : ConnectionViewModel
    {
        public bool CharacterOwnsPlotElement { get; set; }

        public CharacterPlotElementConnectionViewModel()
        {
        }

        public CharacterPlotElementConnectionViewModel(CharacterPlotElementConnectionViewModel viewModel)
            : base(viewModel)
        {
            CharacterOwnsPlotElement = viewModel.CharacterOwnsPlotElement;
        }

        public CharacterPlotElementConnectionViewModel(CharacterPlotElementJoinTable model, Func<(Guid, Guid)> getNodeIdsFunc)
            : base(getNodeIdsFunc)
        {
            CharacterOwnsPlotElement = model.CharacterOwnsPlotElement;
        }


        /// <summary>
        /// Converts the ViewModel to a CharacterPlotElementJoinTable.
        /// </summary>
        /// <param name="getFromObjectFunc">A function that returns the From object for the model.</param>
        /// <param name="getToObjectFunc">A function that returns the To object for the model.</param>
        /// <returns>The CharacterPlotElementJoinTable represented by this ViewModel</returns>
        public CharacterPlotElementJoinTable ToModel(Func<Guid, Character> getFromObjectFunc,
                                                     Func<Guid, PlotElement> getToObjectFunc)
        {
            var viewModel = this.ToModel<Character, PlotElement>(getFromObjectFunc, getToObjectFunc);
            var model = new CharacterPlotElementJoinTable()
            {
                CharacterOwnsPlotElement = this.CharacterOwnsPlotElement,
                LeftEntity = viewModel.LeftEntity,
                RightEntity = viewModel.RightEntity
            };

            return model;
        }

        /// <summary>
        /// Updates <paramref name="model"/> with the values in this ViewModel.
        /// </summary>
        /// <param name="model">The model to update</param>
        public void UpdateModel(CharacterPlotElementJoinTable model)
        {
            this.UpdateModel<Character, PlotElement>(model);
            model.CharacterOwnsPlotElement = this.CharacterOwnsPlotElement;
        }
    }
}
