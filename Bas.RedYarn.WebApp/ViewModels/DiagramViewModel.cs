using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Bas.RedYarn.WebApp.Database;
using Bas.RedYarn.WebApp.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Bas.RedYarn.WebApp.ViewModels
{
    public sealed class DiagramViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public Collection<CharacterViewModel> Characters { get; } = new Collection<CharacterViewModel>();
        public Collection<StorylineViewModel> Storylines { get; } = new Collection<StorylineViewModel>();
        public Collection<PlotElementViewModel> PlotElements { get; } = new Collection<PlotElementViewModel>();
        public Collection<AliasViewModel> Aliases { get; } = new Collection<AliasViewModel>();
        public Collection<RelationshipViewModel> Relationships { get; } = new Collection<RelationshipViewModel>();
        public Collection<ConnectionViewModel> StorylineCharacterConnections { get; } = new Collection<ConnectionViewModel>();
        public Collection<ConnectionViewModel> StorylinePlotElementConnections { get; } = new Collection<ConnectionViewModel>();
        public Collection<CharacterPlotElementConnectionViewModel> CharacterPlotElementConnections { get; } = new Collection<CharacterPlotElementConnectionViewModel>();

        public DiagramViewModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagramViewModel"/> class.
        /// </summary>
        /// <param name="diagram">The <see cref="Diagram"/> for which to create this viewmodel.</param>
        /// <param name="getIdForModelFunc">A function returning the Id for the provided model.</param>
        public DiagramViewModel(RedYarn.Diagram diagram, 
                                Func<object, Guid> getIdForModelFunc = null, 
                                Func<Relationship, Guid, Guid, Guid> getIdForRelationshipFunc = null,
                                Dictionary<RedYarn.Character, CharacterViewModel> characterDictionary = null, 
                                Dictionary<RedYarn.Storyline, StorylineViewModel> storylineDictionary = null, 
                                Dictionary<RedYarn.PlotElement, PlotElementViewModel> plotElementDictionary = null)
        {
            if (getIdForModelFunc != null)
            {
                Id = getIdForModelFunc(diagram);
            }
            Name = diagram.Name;

            characterDictionary = characterDictionary ?? diagram.Characters.ToDictionary(c => c, c => new CharacterViewModel(c, getIdForModelFunc));
            storylineDictionary = storylineDictionary ?? diagram.Storylines.ToDictionary(s => s, s => new StorylineViewModel(s, getIdForModelFunc));
            plotElementDictionary = plotElementDictionary ?? diagram.PlotElements.ToDictionary(p => p, p => new PlotElementViewModel(p, getIdForModelFunc));

            AddStorylines(storylineDictionary);
            AddCharacters(characterDictionary);
            AddPlotElements(plotElementDictionary);

            GenerateStorylineCharacterConnections(storylineDictionary, characterDictionary);
            GenerateRelationships(characterDictionary, getIdForRelationshipFunc);
            GenerateStorylinePlotElementConnections(plotElementDictionary, storylineDictionary);
            GeneratePlotElementConnections(plotElementDictionary, characterDictionary);
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="viewModel">The viewmodel to copy.</param>
        public DiagramViewModel(DiagramViewModel viewModel)
        {
            Id = viewModel.Id;
            Name = viewModel.Name;
            Characters.AddRange(viewModel.Characters);
            Storylines.AddRange(viewModel.Storylines);
            PlotElements.AddRange(viewModel.PlotElements);
            Relationships.AddRange(viewModel.Relationships);
            StorylineCharacterConnections.AddRange(viewModel.StorylineCharacterConnections);
            StorylinePlotElementConnections.AddRange(viewModel.StorylinePlotElementConnections);
            CharacterPlotElementConnections.AddRange(viewModel.CharacterPlotElementConnections);
        }

        /// <summary>
        /// Returns the model this viewmodel represents.
        /// </summary>
        /// <returns>The model this viewmodel represents.</returns>
        public Diagram ToModel()
        {
            // Only set the properties we can set, so don't set shadow properties like the Id.
            return new Diagram()
            {
                Name = Name
            };
        }

        /// <summary>
        /// Update the provided model with the values in this viewmodel.
        /// </summary>
        /// <param name="model">The model to update.</param>
        public void UpdateModel(RedYarn.Diagram model)
        {
            // Only set the properties we can set, so don't set shadow properties like the Id.
            model.Name = Name;
        }
                
        private void AddPlotElements(Dictionary<RedYarn.PlotElement, PlotElementViewModel> plotElementDictionary)
        {
            this.PlotElements.AddRange(plotElementDictionary?.Values);
        }

        private void AddStorylines(Dictionary<RedYarn.Storyline, StorylineViewModel> storylineDictionary)
        {
            this.Storylines.AddRange(storylineDictionary?.Values);            
        }

        private void AddCharacters(Dictionary<RedYarn.Character, CharacterViewModel> characterDictionary)
        {
            this.Characters.AddRange(characterDictionary?.Values);            
        }

        private void GenerateStorylinePlotElementConnections(Dictionary<RedYarn.PlotElement, PlotElementViewModel> plotElementDictionary, Dictionary<RedYarn.Storyline, StorylineViewModel> storylineDictionary)
        {
            foreach (var storyline in storylineDictionary.Keys)
            {
                foreach (var plotElement in storyline.PlotElements)
                {
                    StorylinePlotElementConnections.Add(new ConnectionViewModel()
                    {
                        FromNodeId = storylineDictionary[storyline].Id,
                        ToNodeId = plotElementDictionary[plotElement].Id                        
                    });
                }
            }
        }

        private void GeneratePlotElementConnections(Dictionary<RedYarn.PlotElement, PlotElementViewModel> plotElementDictionary, Dictionary<RedYarn.Character, CharacterViewModel> characterDictionary)
        {
            foreach (var character in characterDictionary.Keys)
            {
                foreach (var neededPlotElement in character.NeededPlotElements)
                {
                    CharacterPlotElementConnections.Add(new CharacterPlotElementConnectionViewModel()
                    {
                        FromNodeId = characterDictionary[character].Id,
                        ToNodeId = plotElementDictionary[neededPlotElement].Id,
                        CharacterOwnsPlotElement = false
                    });
                }

                foreach (var ownedPlotElement in character.OwnedPlotElements)
                {
                    CharacterPlotElementConnections.Add(new CharacterPlotElementConnectionViewModel()
                    {
                        FromNodeId = characterDictionary[character].Id,
                        ToNodeId = plotElementDictionary[ownedPlotElement].Id,
                        CharacterOwnsPlotElement = true
                    });
                }
            }
        }

        private void GenerateStorylineCharacterConnections(Dictionary<RedYarn.Storyline, StorylineViewModel> storylineDictionary, Dictionary<RedYarn.Character, CharacterViewModel> characterDictionary)
        {
            foreach (var storyline in storylineDictionary.Keys)
            {
                foreach (var character in storyline.Characters)
                {
                    StorylineCharacterConnections.Add(new ConnectionViewModel()
                    {
                        FromNodeId = storylineDictionary[storyline].Id,
                        ToNodeId = characterDictionary[character].Id                        
                    });
                }
            }
        }

        private void GenerateRelationships(Dictionary<RedYarn.Character, CharacterViewModel> characterDictionary, Func<Relationship, Guid, Guid, Guid> getIdForRelationshipFunc)
        {
            var uniqueRelationships = new HashSet<Relationship>();
            
            foreach (var character in characterDictionary.Keys)
            {
                foreach (var relationship in character.Relationships)
                {
                    uniqueRelationships.Add(relationship);
                }
            }

            foreach (var relationship in uniqueRelationships)
            {
                Relationships.Add(new RelationshipViewModel()
                {
                    Id = getIdForRelationshipFunc(relationship, 
                                                  characterDictionary[relationship.FirstCharacter].Id,
                                                  characterDictionary[relationship.SecondCharacter].Id),
                    FromNodeId = characterDictionary[relationship.FirstCharacter].Id,
                    ToNodeId = characterDictionary[relationship.SecondCharacter].Id,
                    Name = relationship.Name,
                    IsDirectional = relationship.IsDirectional
                });
            }
        }
    }
}
