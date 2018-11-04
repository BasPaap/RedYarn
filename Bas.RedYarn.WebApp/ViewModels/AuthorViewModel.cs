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

        public AuthorViewModel(AuthorViewModel viewModel)
        {
            Id = viewModel.Id;
            Name = viewModel.Name;                
        }

        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public RedYarn.Author ToModel()
        {
            return new Author()
            {
                Name = Name
            };
        }

        public void UpdateModel(RedYarn.Author model)
        {
            model.Name = Name;
        }
    }

}