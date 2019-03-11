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
        public Collection<AuthorViewModel> Authors { get; } = new Collection<AuthorViewModel>();

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

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="viewModel">The viewmodel to copy.</param>
        public CharacterViewModel(CharacterViewModel viewModel)
        {
            Id = viewModel.Id;
            Name = viewModel.Name;
            Description = viewModel.Description;
            XPosition = viewModel.XPosition;
            YPosition = viewModel.YPosition;
            Aliases.AddRange(viewModel.Aliases);
            Authors.AddRange(viewModel.Authors);
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

        /// <summary>
        /// Initializes a new instance of the <see cref="CharacterViewModel"/> class.
        /// </summary>
        /// <param name="character">The <see cref="Character"/> for which to create this viewmodel.</param>
        /// <param name="characterNode">The <see cref="CharacterNode"/> with which to create this viewmodel.</param>
        /// <param name="getIdForModelFunc">A function returning the Id for the provided model.</param>
        public CharacterViewModel(RedYarn.Character character, Database.CharacterNode characterNode, Func<object, Guid> getIdForModelFunc = null)
            : this(character, characterNode.XPosition, characterNode.YPosition, getIdForModelFunc)
        {
        }

        /// <summary>
        /// Returns the model this viewmodel represents.
        /// </summary>
        /// <returns>The model this viewmodel represents.</returns>
        public RedYarn.Character ToModel()
        {
            // Only set the properties we can set, so don't set shadow properties like the Id.
            var character = new Character()
            {
                Name = Name,
                Description = Description
            };

            character.Aliases.AddRange(this.Aliases.Select(alias => new Alias()
            {
                Name = alias.Name
            }));

            character.Authors.AddRange(this.Authors.Select(author => new Author()
            {
                Name = author.Name
            }));

            return character;
        }

        /// <summary>
        /// Returns the Node entity this viewmodel represents (in other words, return StorylineNode, not Storyline).
        /// </summary>
        /// <returns>The node entity this viewmodel represents.</returns>
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

        /// <summary>
        /// Update the provided model with the values in this viewmodel.
        /// </summary>
        /// <param name="model">The model to update.</param>
        public void UpdateModel(RedYarn.Character model)
        {
            // Only set the properties we can set, so don't set shadow properties like the Id.
            model.Name = Name;
            model.Description = Description;

            // Aliases are specific to this character, so we can safely delete all aliases attached to the model and add the ones in this viewmodel.
            model.Aliases.Clear();
            model.Aliases.AddRange(Aliases.Select(aliasViewModel => new Alias() { Name = aliasViewModel.Name }));

            model.Authors.Clear();
            model.Authors.AddRange(Authors.Select(authorViewModel => new Author() { Name = authorViewModel.Name }));
        }

        /// <summary>
        /// Update the provided model with the values in this viewmodel.
        /// </summary>
        /// <param name="model">The model to update.</param>
        public void UpdateNode(Database.CharacterNode node)
        {
            node.XPosition = XPosition;
            node.YPosition = YPosition;
        }
    }
}