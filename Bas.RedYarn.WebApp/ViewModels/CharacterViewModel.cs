using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Bas.RedYarn.WebApp.Database;
using Bas.RedYarn.WebApp.Extensions;


namespace Bas.RedYarn.WebApp.ViewModels
{
    public sealed class CharacterViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public float XPosition { get; set; }
        public float YPosition { get; set; }
        public Collection<AliasViewModel> Aliases { get; } = new Collection<AliasViewModel>();

        public CharacterViewModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CharacterViewModel"/> class.
        /// </summary>
        /// <param name="character">The <see cref="Character"/> for which to create this viewmodel.</param>
        /// <param name="getIdForModelFunc">A function returning the Id for the provided model.</param>
        public CharacterViewModel(RedYarn.Character character, Func<object, Guid> getIdForModelFunc = null)
        {
            if (getIdForModelFunc != null)
            {
                Id = getIdForModelFunc(character);
            }
            Name = character.Name;
            Description = character.Description;
            Aliases.AddRange(character.Aliases.Select(alias => new AliasViewModel(alias, getIdForModelFunc)).ToList());
        }

        public CharacterViewModel(CharacterViewModel viewModel)
        {
            Id = viewModel.Id;
            Name = viewModel.Name;
            Description = viewModel.Description;
            XPosition = viewModel.XPosition;
            YPosition = viewModel.YPosition;
            Aliases.AddRange(viewModel.Aliases);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CharacterViewModel"/> class.
        /// </summary>
        /// <param name="character">The <see cref="Character"/> for which to create this viewmodel.</param>
        /// <param name="xPosition">The X position of the viewmodel in the diagram.</param>
        /// <param name="yPosition">The Y position of the viewmodel in the diagram.</param>
        /// <param name="getIdForModelFunc">A function returning the Id for the provided model.</param>
        public CharacterViewModel(RedYarn.Character character, float xPosition, float yPosition, Func<object, Guid> getIdForModelFunc = null)
            : this(character, getIdForModelFunc)
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

            character.Aliases.AddRange(this.Aliases.Select(alias => new Alias()
            {
                Name = alias.Name
            }));

            return character;
        }

        public void UpdateModel(RedYarn.Character model)
        {
            model.Name = Name;
            model.Description = Description;
            model.Aliases.Clear();
            model.Aliases.AddRange(Aliases.Select(aliasViewModel => new Alias() { Name = aliasViewModel.Name }));
        }

        public Database.CharacterNode ToNode()
        {
            return new CharacterNode()
            {
                Character = ToModel(),
                Id = Id,
                XPosition = XPosition,
                YPosition = YPosition
            };            
        }

        public void UpdateNode(Database.CharacterNode node)
        {
            node.XPosition = XPosition;
            node.YPosition = YPosition;
        }


    }
}