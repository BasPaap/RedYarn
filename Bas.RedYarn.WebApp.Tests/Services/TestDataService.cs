using Bas.RedYarn.WebApp.Model;
using Bas.RedYarn.WebApp.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bas.RedYarn.WebApp.Tests.Services
{
    sealed class TestDataService : IDataService
    {
        private Author firstAuthor = new Author() { Name = "FirstAuthor" };
        private Author secondAuthor = new Author() { Name = "SecondAuthor" };
        private Character firstCharacter = new Character() { Name = "FirstCharacter" };
        private Character secondCharacter = new Character() { Name = "SecondCharacter" };
        private Storyline firstStoryline = new Storyline() { Name = "FirstStoryline", Description = "FirstStorylineDescription" };
        private Storyline secondStoryline = new Storyline() { Name = "SecondStoryline", Description = "SecondStorylineDescription" };
        private Diagram diagram = new Diagram() { Name = "Diagram" };

        private const string relationshipFromFirstToSecondName = "RelationshipFromFirstToSecond";
        private const string relationshipFromSecondToFirstName = "RelationshipFromSecondToFirst";

        public TestDataService()
        {
            firstCharacter.Aliases.Add("FirstAlias");
            firstCharacter.Aliases.Add("SecondAlias");
            firstCharacter.Authors.Add(firstAuthor);
            firstCharacter.Storylines.Add(firstStoryline);
            firstCharacter.Storylines.Add(secondStoryline);
            
            secondCharacter.Authors.Add(firstAuthor);
            secondCharacter.Authors.Add(secondAuthor);
            secondCharacter.Storylines.Add(firstStoryline);

            firstCharacter.RelateTo(secondCharacter, relationshipFromFirstToSecondName, relationshipFromSecondToFirstName);
                        
            diagram.Authors.Add(firstAuthor);
            diagram.Authors.Add(secondAuthor);
            diagram.Characters.Add(firstCharacter);
            diagram.Characters.Add(secondCharacter);
            diagram.Storylines.Add(firstStoryline);
            diagram.Storylines.Add(secondStoryline);
        }

        public Diagram GetDiagram(int id)
        {            
            return diagram;
        }

        public Model.Diagram ExpectedModel
        {
            get
            {
                var firstCharacterModel = GetCharacterModel(firstCharacter);
                firstCharacterModel.Aliases.Add(firstCharacter.Aliases[0]);
                firstCharacterModel.Aliases.Add(firstCharacter.Aliases[1]);

                var secondCharacterModel = GetCharacterModel(secondCharacter);

                var firstStorylineModel = GetStorylineModel(firstStoryline);
                var secondStorylineModel = GetStorylineModel(firstStoryline);

                var firstRelationship = GetRelationship(firstCharacterModel, secondCharacterModel, relationshipFromFirstToSecondName);
                var secondRelationship = GetRelationship(secondCharacterModel, firstCharacterModel, relationshipFromSecondToFirstName);

                var firstStorylineConnection = GetStorylineConnection(firstCharacterModel, firstStorylineModel);
                var secondStorylineConnection = GetStorylineConnection(firstCharacterModel, secondStorylineModel);
                var thirdStorylineConnection = GetStorylineConnection(secondCharacterModel, firstStorylineModel);

                var diagramModel = new Model.Diagram() { Name = diagram.Name };
                diagramModel.Characters.Add(firstCharacterModel);
                diagramModel.Characters.Add(secondCharacterModel);
                diagramModel.Storylines.Add(firstStorylineModel);
                diagramModel.Storylines.Add(secondStorylineModel);
                diagramModel.Relationships.Add(firstRelationship);
                diagramModel.Relationships.Add(secondRelationship);

                return diagramModel;
            }
        }

        private Model.Character GetCharacterModel(Character character)
        {
            return new Model.Character()
            {
                Id = Guid.NewGuid(),
                Name = character.Name,
                Description = character.Description
            };
        }

        private Model.Storyline GetStorylineModel(Storyline storyline)
        {
            return new Model.Storyline()
            {
                Id = Guid.NewGuid(),
                Name = storyline.Name,
                Description = storyline.Description
            };
        }

        private Model.Relationship GetRelationship(Model.Character firstCharacterModel, Model.Character secondCharacterModel, string name)
        {
            return new Model.Relationship()
            {
                FromCharacterId = firstCharacterModel.Id,
                ToCharacterId = secondCharacterModel.Id,
                Name = name
            };
        }                

        private Model.StorylineConnection GetStorylineConnection(Model.Character characterModel, Model.Storyline storylineModel)
        {
            return new Model.StorylineConnection()
            {
                CharacterId = characterModel.Id,
                StorylineId = storylineModel.Id
            };
        }
    }
}
