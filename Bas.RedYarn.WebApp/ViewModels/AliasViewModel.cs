using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bas.RedYarn.WebApp.ViewModels
{
    public sealed class AliasViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public AliasViewModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AliasViewModel"/> class.
        /// </summary>
        /// <param name="alias">The <see cref="Alias"/> for which to create this viewmodel.</param>
        /// <param name="getIdForModelFunc">A function returning the Id for the provided model.</param>
        public AliasViewModel(Alias alias, Func<object, Guid> getIdForModelFunc = null)
        {
            if (getIdForModelFunc != null)
            {
                Id = getIdForModelFunc(alias);
            }            
            Name = alias.Name;
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="viewModel">The viewmodel to copy.</param>
        public AliasViewModel(AliasViewModel viewModel)
        {
            Id = viewModel.Id;
            Name = viewModel.Name;
        }

        /// <summary>
        /// Returns the model this viewmodel represents.
        /// </summary>
        /// <returns>The model this viewmodel represents.</returns>
        public RedYarn.Alias ToModel()
        {
            // Only set the properties we can set, so don't set shadow properties like the Id.
            return new Alias()
            {
                Name = Name
            };
        }

        /// <summary>
        /// Update the provided model with the values in this viewmodel.
        /// </summary>
        /// <param name="model">The model to update.</param>
        public void UpdateModel(RedYarn.Alias model)
        {
            // Only set the properties we can set, so don't set shadow properties like the Id.
            model.Name = Name;
        }
    }
}