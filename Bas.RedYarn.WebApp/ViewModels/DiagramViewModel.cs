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
        public Collection<StorylineConnectionViewModel> StorylineCharacterConnections { get; } = new Collection<StorylineConnectionViewModel>();
        public Collection<StorylineConnectionViewModel> StorylinePlotElementConnections { get; } = new Collection<StorylineConnectionViewModel>();
        public Collection<PlotElementConnectionViewModel> CharacterPlotElementConnections { get; } = new Collection<PlotElementConnectionViewModel>();

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
            GenerateRelationships(characterDictionary);
            GenerateStorylinePlotElementConnections(plotElementDictionary, storylineDictionary);
            GeneratePlotElementConnections(plotElementDictionary, characterDictionary);
        }

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
        
        public Diagram ToModel()
        {
            return new Diagram()
            {
                Name = Name
            };
        }

        public void UpdateModel(RedYarn.Diagram model)
        {
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
                    StorylinePlotElementConnections.Add(new StorylineConnectionViewModel()
                    {
                        ConnectionId = plotElementDictionary[plotElement].Id,
                        StorylineId = storylineDictionary[storyline].Id
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
                    CharacterPlotElementConnections.Add(new PlotElementConnectionViewModel()
                    {
                        PlotElementId = plotElementDictionary[neededPlotElement].Id,
                        CharacterId = characterDictionary[character].Id,
                        CharacterOwnsPlotElement = false
                    });
                }

                foreach (var ownedPlotElement in character.OwnedPlotElements)
                {
                    CharacterPlotElementConnections.Add(new PlotElementConnectionViewModel()
                    {
                        PlotElementId = plotElementDictionary[ownedPlotElement].Id,
                        CharacterId = characterDictionary[character].Id,
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
                    StorylineCharacterConnections.Add(new StorylineConnectionViewModel()
                    {
                        ConnectionId = characterDictionary[character].Id,
                        StorylineId = storylineDictionary[storyline].Id
                    });
                }
            }
        }

        private void GenerateRelationships(Dictionary<RedYarn.Character, CharacterViewModel> characterDictionary)
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
                    FirstCharacterId = characterDictionary[relationship.FirstCharacter].Id,
                    SecondCharacterId = characterDictionary[relationship.SecondCharacter].Id,
                    Name = relationship.Name,
                    IsDirectional = relationship.IsDirectional
                });
            }
        }
    }
}
