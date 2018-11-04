﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bas.RedYarn.WebApp.ViewModels
{
    public sealed class TagViewModel
    {
        public TagViewModel()
        {
        }

        public TagViewModel(Tag tag)
        {
            Name = tag.Name;
            Category = tag.Category;
        }

        public TagViewModel(TagViewModel viewModel)
        {
            Id = viewModel.Id;
            Name = viewModel.Name;
            Category = viewModel.Category;
        }

        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Category { get; set; }

        public RedYarn.Tag ToModel()
        {
            return new Tag()
            {
                Name = Name,
                Category = Category
            };
        }

        public void UpdateModel(RedYarn.Tag model)
        {
            model.Name = Name;
            model.Category = Category;
        }
    }

}