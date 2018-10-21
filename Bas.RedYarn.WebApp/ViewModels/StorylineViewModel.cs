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

        public StorylineViewModel()
        {
        }

        public StorylineViewModel(RedYarn.Storyline storyline)
        {
            Id = Guid.NewGuid();
            Name = storyline.Name;
            Description = storyline.Description;
        }
    }
}