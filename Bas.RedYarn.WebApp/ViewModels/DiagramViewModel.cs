using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Bas.RedYarn.WebApp.Extensions;

namespace Bas.RedYarn.WebApp.ViewModels
{
    public sealed class DiagramViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Collection<CharacterViewModel> Characters { get; } = new Collection<CharacterViewModel>();
        public Collection<StorylineViewModel> Storylines { get; } = new Collection<StorylineViewModel>();
        public Collection<PlotElementViewModel> PlotElements { get; } = new Collection<PlotElementViewModel>();

        public Collection<RelationshipViewModel> Relationships { get; } = new Collection<RelationshipViewModel>();
        public Collection<StorylineConnectionViewModel> StorylineCharacterConnections { get; } = new Collection<StorylineConnectionViewModel>();
        public Collection<StorylineConnectionViewModel> StorylinePlotElementConnections { get; } = new Collection<StorylineConnectionViewModel>();
        public Collection<PlotElementConnectionViewModel> CharacterPlotElementConnections { get; set; } = new Collection<PlotElementConnectionViewModel>();
        public DiagramViewModel()
        {
        }

        public DiagramViewModel(RedYarn.Diagram diagram)
        {
            Name = diagram.Name;

            var characterDictionary = new Dictionary<RedYarn.Character, ViewModels.CharacterViewModel>(diagram.Characters.Select(c => new KeyValuePair<RedYarn.Character, ViewModels.CharacterViewModel>(c, new ViewModels.CharacterViewModel(c))));
            var storylineDictionary = new Dictionary<RedYarn.Storyline, ViewModels.StorylineViewModel>(diagram.Storylines.Select(s => new KeyValuePair<RedYarn.Storyline, ViewModels.StorylineViewModel>(s, new ViewModels.StorylineViewModel(s))));
            var plotElementDictionary = new Dictionary<RedYarn.PlotElement, ViewModels.PlotElementViewModel>(diagram.PlotElements.Select(e => new KeyValuePair<RedYarn.PlotElement, PlotElementViewModel>(e, new ViewModels.PlotElementViewModel(e))));

            AddStorylines(storylineDictionary);
            AddCharacters(characterDictionary);
            AddPlotElements(plotElementDictionary);

            GenerateStorylineCharacterConnections(storylineDictionary, characterDictionary);
            GenerateRelationships(characterDictionary);
            GenerateStorylinePlotElementConnections(plotElementDictionary, storylineDictionary);
            GeneratePlotElementConnections(plotElementDictionary, characterDictionary);
        }
                
        private void AddPlotElements(Dictionary<RedYarn.PlotElement, PlotElementViewModel> plotElementDictionary)
        {
            this.PlotElements.AddRange(plotElementDictionary.Values);
        }

        private void AddStorylines(Dictionary<RedYarn.Storyline, StorylineViewModel> storylineDictionary)
        {
            this.Storylines.AddRange(storylineDictionary.Values);            
        }

        private void AddCharacters(Dictionary<RedYarn.Character, CharacterViewModel> characterDictionary)
        {
            this.Characters.AddRange(characterDictionary.Values);            
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
            var uniqueRelationships = new HashSet<IRelationship>();
            
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
                    FromCharacterId = characterDictionary[relationship.FirstCharacter].Id,
                    ToCharacterId = characterDictionary[relationship.SecondCharacter].Id,
                    Name = relationship.Name,
                    IsDirectional = relationship.IsDirectional
                });
            }
        }
    }
}
