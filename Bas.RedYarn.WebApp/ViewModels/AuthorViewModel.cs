using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bas.RedYarn.WebApp.ViewModels
{
    public sealed class AuthorViewModel
    {
        public AuthorViewModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorViewModel"/> class.
        /// </summary>
        /// <param name="author">The <see cref="Author"/> for which to create this viewmodel.</param>
        /// <param name="getIdForModelFunc">A function returning the Id for the provided model.</param>
        public AuthorViewModel(Author author, Func<object, Guid> getIdForModelFunc = null)
        {
            if (getIdForModelFunc != null)
            {
                Id = getIdForModelFunc(author);
            }
            Name = author.Name;
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="viewModel">The viewmodel to copy.</param>
        public AuthorViewModel(AuthorViewModel viewModel)
        {
            Id = viewModel.Id;
            Name = viewModel.Name;                
        }

        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Returns the model this viewmodel represents.
        /// </summary>
        /// <returns>The model this viewmodel represents.</returns>
        public RedYarn.Author ToModel()
        {
            // Only set the properties we can set, so don't set shadow properties like the Id.
            return new Author()
            {
                Name = Name
            };
        }

        /// <summary>
        /// Update the provided model with the values in this viewmodel.
        /// </summary>
        /// <param name="model">The model to update.</param>
        public void UpdateModel(RedYarn.Author model)
        {
            // Only set the properties we can set, so don't set shadow properties like the Id.
            model.Name = Name;
        }
    }

}