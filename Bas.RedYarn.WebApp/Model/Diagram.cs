using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Bas.RedYarn.WebApp.Model
{
    public sealed class Diagram
    {
        public string Name { get; set; }
        public Collection<Character> Characters { get; } = new Collection<Character>();
        public Collection<Storyline> Storylines { get; } = new Collection<Storyline>();
        public Collection<PlotElement> PlotElements { get; } = new Collection<PlotElement>();

        public Collection<Relationship> Relationships { get; } = new Collection<Relationship>();
        public Collection<StorylineConnection> StorylineCharacterConnections { get; } = new Collection<StorylineConnection>();
        public Collection<StorylineConnection> StorylinePlotElementConnections { get; } = new Collection<StorylineConnection>();
        public Collection<PlotElementConnection> CharacterPlotElementConnections { get; set; } = new Collection<PlotElementConnection>();
        public Diagram()
        {
        }

        public Diagram(RedYarn.Diagram diagram)
        {
            Name = diagram.Name;

            var characterDictionary = new Dictionary<RedYarn.Character, Model.Character>(diagram.Characters.Select(c => new KeyValuePair<RedYarn.Character, Model.Character>(c, new Model.Character(c))));
            var storylineDictionary = new Dictionary<RedYarn.Storyline, Model.Storyline>(diagram.Storylines.Select(s => new KeyValuePair<RedYarn.Storyline, Model.Storyline>(s, new Model.Storyline(s))));
            var plotElementDictionary = new Dictionary<RedYarn.PlotElement, Model.PlotElement>(diagram.PlotElements.Select(e => new KeyValuePair<RedYarn.PlotElement, PlotElement>(e, new Model.PlotElement(e))));

            AddStorylines(storylineDictionary);
            AddCharacters(characterDictionary);
            AddPlotElements(plotElementDictionary);

            GenerateStorylineCharacterConnections(storylineDictionary, characterDictionary);
            GenerateRelationships(characterDictionary);
            GenerateStorylinePlotElementConnections(plotElementDictionary, storylineDictionary);
            GeneratePlotElementConnections(plotElementDictionary, characterDictionary);
        }
                
        private void AddPlotElements(Dictionary<RedYarn.PlotElement, PlotElement> plotElementDictionary)
        {
            foreach (var plotElement in plotElementDictionary.Keys)
            {
                this.PlotElements.Add(plotElementDictionary[plotElement]);
            }
        }

        private void AddStorylines(Dictionary<RedYarn.Storyline, Storyline> storylineDictionary)
        {
            foreach (var storyline in storylineDictionary.Keys)
            {
                this.Storylines.Add(storylineDictionary[storyline]);
            }
        }

        private void AddCharacters(Dictionary<RedYarn.Character, Character> characterDictionary)
        {
            foreach (var character in characterDictionary.Keys)
            {
                this.Characters.Add(characterDictionary[character]);
            }
        }

        private void GenerateStorylinePlotElementConnections(Dictionary<RedYarn.PlotElement, PlotElement> plotElementDictionary, Dictionary<RedYarn.Storyline, Storyline> storylineDictionary)
        {
            foreach (var storyline in storylineDictionary.Keys)
            {
                foreach (var plotElement in storyline.PlotElements)
                {
                    StorylinePlotElementConnections.Add(new StorylineConnection()
                    {
                        ConnectionId = plotElementDictionary[plotElement].Id,
                        StorylineId = storylineDictionary[storyline].Id
                    });
                }
            }
        }

        private void GeneratePlotElementConnections(Dictionary<RedYarn.PlotElement, PlotElement> plotElementDictionary, Dictionary<RedYarn.Character, Character> characterDictionary)
        {
            foreach (var character in characterDictionary.Keys)
            {
                foreach (var neededPlotElement in character.NeededPlotElements)
                {
                    CharacterPlotElementConnections.Add(new PlotElementConnection()
                    {
                        PlotElementId = plotElementDictionary[neededPlotElement].Id,
                        CharacterId = characterDictionary[character].Id,
                        CharacterOwnsPlotElement = false
                    });
                }

                foreach (var ownedPlotElement in character.OwnedPlotElements)
                {
                    CharacterPlotElementConnections.Add(new PlotElementConnection()
                    {
                        PlotElementId = plotElementDictionary[ownedPlotElement].Id,
                        CharacterId = characterDictionary[character].Id,
                        CharacterOwnsPlotElement = true
                    });
                }
            }
        }

        private void GenerateStorylineCharacterConnections(Dictionary<RedYarn.Storyline, Storyline> storylineDictionary, Dictionary<RedYarn.Character, Character> characterDictionary)
        {
            foreach (var storyline in storylineDictionary.Keys)
            {
                foreach (var character in storyline.Characters)
                {
                    StorylineCharacterConnections.Add(new StorylineConnection()
                    {
                        ConnectionId = characterDictionary[character].Id,
                        StorylineId = storylineDictionary[storyline].Id
                    });
                }
            }
        }

        private void GenerateRelationships(Dictionary<RedYarn.Character, Character> characterDictionary)
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
                Relationships.Add(new Relationship()
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
