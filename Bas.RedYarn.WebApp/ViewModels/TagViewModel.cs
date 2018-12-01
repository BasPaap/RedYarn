using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bas.RedYarn.WebApp.ViewModels
{
    public sealed class TagViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Category { get; set; }

        public TagViewModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TagViewModel"/> class.
        /// </summary>
        /// <param name="tag">The <see cref="TagViewModel"/> for which to create this viewmodel.</param>
        /// <param name="getIdForModelFunc">A function returning the Id for the provided model.</param>
        public TagViewModel(Tag tag, Func<object, Guid> getIdForModelFunc = null)
        {
            if (getIdForModelFunc != null)
            {
                Id = getIdForModelFunc(tag);
            }
            Name = tag.Name;
            Category = tag.Category;
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="viewModel">The viewmodel to copy.</param>
        public TagViewModel(TagViewModel viewModel)
        {
            Id = viewModel.Id;
            Name = viewModel.Name;
            Category = viewModel.Category;
        }

        /// <summary>
        /// Returns the model this viewmodel represents.
        /// </summary>
        /// <returns>The model this viewmodel represents.</returns>
        public RedYarn.Tag ToModel()
        {
            // Only set the properties we can set, so don't set shadow properties like the Id.
            return new Tag()
            {
                Name = Name,
                Category = Category
            };
        }

        /// <summary>
        /// Update the provided model with the values in this viewmodel.
        /// </summary>
        /// <param name="model">The model to update.</param>
        public void UpdateModel(RedYarn.Tag model)
        {
            // Only set the properties we can set, so don't set shadow properties like the Id.
            model.Name = Name;
            model.Category = Category;
        }
    }

}