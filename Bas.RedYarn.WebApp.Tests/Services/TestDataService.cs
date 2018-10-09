using Bas.RedYarn.WebApp.Model;
using Bas.RedYarn.WebApp.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bas.RedYarn.WebApp.Tests.Services
{
    sealed class TestDataService : IDataService
    {
        private readonly Author firstAuthor = new Author() { Name = "FirstAuthor" };
        private readonly Author secondAuthor = new Author() { Name = "SecondAuthor" };
        private Character firstCharacter = new Character() { Name = "FirstCharacter" };
        private Character secondCharacter = new Character() { Name = "SecondCharacter" };
        private readonly Storyline firstStoryline = new Storyline() { Name = "FirstStoryline", Description = "FirstStorylineDescription" };
        private readonly Storyline secondStoryline = new Storyline() { Name = "SecondStoryline", Description = "SecondStorylineDescription" };
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
                var firstCharacterModel = new Model.Character(firstCharacter);
                var secondCharacterModel = new Model.Character(secondCharacter);

                var firstStorylineModel = new Model.Storyline(firstStoryline);
                var secondStorylineModel = new Model.Storyline(secondStoryline);

                var firstRelationship = GetRelationship(firstCharacterModel, secondCharacterModel, relationshipFromFirstToSecondName);
                var secondRelationship = GetRelationship(secondCharacterModel, firstCharacterModel, relationshipFromSecondToFirstName);
                
                var firstStorylineConnection = GetStorylineConnection(firstCharacterModel, firstStorylineModel);
                var secondStorylineConnection = GetStorylineConnection(firstCharacterModel, secondStorylineModel);
                var thirdStorylineConnection = GetStorylineConnection(secondCharacterModel, firstStorylineModel);

                var diagramModel = new Model.Diagram(diagram);
                diagramModel.Characters.Add(firstCharacterModel);
                diagramModel.Characters.Add(secondCharacterModel);
                diagramModel.Storylines.Add(firstStorylineModel);
                diagramModel.Storylines.Add(secondStorylineModel);
                diagramModel.Relationships.Add(firstRelationship);
                diagramModel.Relationships.Add(secondRelationship);
                diagramModel.StorylineConnections.Add(firstStorylineConnection);
                diagramModel.StorylineConnections.Add(secondStorylineConnection);
                diagramModel.StorylineConnections.Add(thirdStorylineConnection);

                return diagramModel;
            }
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
