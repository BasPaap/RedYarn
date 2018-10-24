using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

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

            foreach (var alias in character.Aliases)
            {
                Aliases.Add(alias);
            }
        }

        public CharacterViewModel(RedYarn.Character character, float xPosition, float yPosition)
            : this(character)
        {            
            XPosition = xPosition;
            YPosition = yPosition;
        }
    }
}