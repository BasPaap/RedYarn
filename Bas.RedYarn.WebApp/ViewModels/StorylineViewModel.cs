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
        public float YPosition { get; set; }
        public float XPosition { get; set; }

        public StorylineViewModel()
        {
        }

        public StorylineViewModel(RedYarn.Storyline storyline, Func<object, Guid> getIdForModelFunc = null)
        {
            Id = getIdForModelFunc(storyline);
            Name = storyline.Name;
            Description = storyline.Description;
        }

        public StorylineViewModel(Storyline storyline, float xPosition, float yPosition, Func<object, Guid> getIdForModelFunc = null)
            : this(storyline, getIdForModelFunc)
        {
            XPosition = xPosition;
            YPosition = yPosition;
        }

        public StorylineViewModel(StorylineViewModel viewModel)
        {
            Id = viewModel.Id;
            Name = viewModel.Name;
            Description = viewModel.Description;
            YPosition = viewModel.YPosition;
            XPosition = viewModel.XPosition;
        }

        public Storyline ToModel()
        {
            return new Storyline()
            {
                Name = Name,
                Description = Description
            };
        }

        public void UpdateModel(Storyline model)
        {
            model.Name = Name;
            model.Description = Description;
        }

        public Database.StorylineNode ToNode()
        {
            return new Database.StorylineNode()
            {
                Storyline = ToModel(),
                Id = Id,
                XPosition = XPosition,
                YPosition = YPosition
            };
        }

        public void UpdateNode(Database.StorylineNode node)
        {
            node.XPosition = XPosition;
            node.YPosition = YPosition;
        }
    }
}