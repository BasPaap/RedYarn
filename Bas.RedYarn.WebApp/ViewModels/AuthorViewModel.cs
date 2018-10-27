﻿using System;
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

        public AuthorViewModel(Author author)
        {
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