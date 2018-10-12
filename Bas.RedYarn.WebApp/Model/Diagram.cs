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
        public Collection<EssentialPlotElement> EssentialPlotElements { get; } = new Collection<EssentialPlotElement>();

        public Collection<Relationship> Relationships { get; } = new Collection<Relationship>();
        public Collection<StorylineConnection> StorylineCharacterConnections { get; } = new Collection<StorylineConnection>();
        public Collection<StorylineConnection> StorylineEssentialPlotElementConnections { get; } = new Collection<StorylineConnection>();
        public Collection<EssentialPlotElementConnection> CharacterEssentialPlotElementConnections { get; set; } = new Collection<EssentialPlotElementConnection>();
        public Diagram()
        {
        }

        public Diagram(RedYarn.Diagram diagram)
        {
            Name = diagram.Name;

            var characterDictionary = new Dictionary<RedYarn.Character, Model.Character>(diagram.Characters.Select(c => new KeyValuePair<RedYarn.Character, Model.Character>(c, new Model.Character(c))));
            var storylineDictionary = new Dictionary<RedYarn.Storyline, Model.Storyline>(diagram.Storylines.Select(s => new KeyValuePair<RedYarn.Storyline, Model.Storyline>(s, new Model.Storyline(s))));
            var essentialPlotElementDictionary = new Dictionary<RedYarn.EssentialPlotElement, Model.EssentialPlotElement>(diagram.EssentialPlotElements.Select(e => new KeyValuePair<RedYarn.EssentialPlotElement, EssentialPlotElement>(e, new Model.EssentialPlotElement(e))));

            AddStorylines(storylineDictionary);
            AddCharacters(characterDictionary);
            AddEssentialPlotElements(essentialPlotElementDictionary);

            GenerateStorylineCharacterConnections(storylineDictionary, characterDictionary);
            GenerateRelationships(characterDictionary);
            GenerateStorylineEssentialPlotElementConnections(essentialPlotElementDictionary, storylineDictionary);
            GenerateEssentialPlotElementConnections(essentialPlotElementDictionary, characterDictionary);
        }
                
        private void AddEssentialPlotElements(Dictionary<RedYarn.EssentialPlotElement, EssentialPlotElement> essentialPlotElementDictionary)
        {
            foreach (var essentialPlotElement in essentialPlotElementDictionary.Keys)
            {
                this.EssentialPlotElements.Add(essentialPlotElementDictionary[essentialPlotElement]);
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

        private void GenerateStorylineEssentialPlotElementConnections(Dictionary<RedYarn.EssentialPlotElement, EssentialPlotElement> essentialPlotElementDictionary, Dictionary<RedYarn.Storyline, Storyline> storylineDictionary)
        {
            foreach (var storyline in storylineDictionary.Keys)
            {
                foreach (var essentialPlotElement in storyline.EssentialPlotElements)
                {
                    StorylineEssentialPlotElementConnections.Add(new StorylineConnection()
                    {
                        ConnectionId = essentialPlotElementDictionary[essentialPlotElement].Id,
                        StorylineId = storylineDictionary[storyline].Id
                    });
                }
            }
        }

        private void GenerateEssentialPlotElementConnections(Dictionary<RedYarn.EssentialPlotElement, EssentialPlotElement> essentialPlotElementDictionary, Dictionary<RedYarn.Character, Character> characterDictionary)
        {
            foreach (var character in characterDictionary.Keys)
            {
                foreach (var neededPlotElement in character.NeededPlotElements)
                {
                    CharacterEssentialPlotElementConnections.Add(new EssentialPlotElementConnection()
                    {
                        EssentialPlotElementId = essentialPlotElementDictionary[neededPlotElement].Id,
                        CharacterId = characterDictionary[character].Id,
                        CharacterOwnsPlotElement = false
                    });
                }

                foreach (var ownedPlotElement in character.OwnedPlotElements)
                {
                    CharacterEssentialPlotElementConnections.Add(new EssentialPlotElementConnection()
                    {
                        EssentialPlotElementId = essentialPlotElementDictionary[ownedPlotElement].Id,
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
