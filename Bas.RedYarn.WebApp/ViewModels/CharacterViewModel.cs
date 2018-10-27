using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Bas.RedYarn.WebApp.Extensions;

namespace Bas.RedYarn.WebApp.ViewModels
{
    public sealed class CharacterViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public Collection<string> Aliases { get; } = new Collection<string>();
        public float XPosition { get; set; }
        public float YPosition { get; set; }

        public CharacterViewModel()
        {
        }

        public CharacterViewModel(RedYarn.Character character)
        {
            Id = Guid.NewGuid();
            Name = character.Name;
            Description = character.Description;
            Aliases.AddRange(character.Aliases);            
        }

        public CharacterViewModel(CharacterViewModel viewModel)
        {
            Id = viewModel.Id;
            Name = viewModel.Name;
            Description = viewModel.Description;
            Aliases.AddRange(character.Aliases);
            XPosition = viewModel.XPosition;
            YPosition = viewModel.YPosition;            
        }

        public CharacterViewModel(RedYarn.Character character, float xPosition, float yPosition)
            : this(character)
        {            
            XPosition = xPosition;
            YPosition = yPosition;
        }

        public RedYarn.Character ToModel()
        {
            var character = new Character()
            {
                Name = Name,
                Description = Description
            };

            character.Aliases.AddRange(Aliases);

            return character;
        }
    }
}