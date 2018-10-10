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
        public Collection<Relationship> Relationships { get; } = new Collection<Relationship>();
        public Collection<StorylineConnection> StorylineConnections { get; } = new Collection<StorylineConnection>();

        public Diagram()
        {
        }

        public Diagram(RedYarn.Diagram diagram)
        {
            Name = diagram.Name;
        }

        internal void AddStorylines(Dictionary<RedYarn.Storyline, Storyline> storylineDictionary)
        {
            foreach (var storyline in storylineDictionary.Keys)
            {
                this.Storylines.Add(new Storyline(storyline));
            }
        }

        internal void AddCharacters(Dictionary<RedYarn.Character, Character> characterDictionary)
        {
            foreach (var character in characterDictionary.Keys)
            {
                this.Characters.Add(new Character(character));
            }
        }

        internal void GenerateStorylineConnections(Dictionary<RedYarn.Storyline, Storyline> storylineDictionary, Dictionary<RedYarn.Character, Character> characterDictionary)
        {
            foreach (var storyline in storylineDictionary.Keys)
            {
                foreach (var character in storyline.Characters)
                {
                    StorylineConnections.Add(new Model.StorylineConnection()
                    {
                        CharacterId = characterDictionary[character].Id,
                        StorylineId = storylineDictionary[storyline].Id
                    });
                }
            }
        }

        internal void GenerateRelationships(Dictionary<RedYarn.Character, Character> characterDictionary)
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
                    Name = relationship.Name
                });
            }
        }
    }
}
