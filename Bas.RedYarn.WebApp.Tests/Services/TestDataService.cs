﻿using Bas.RedYarn.WebApp.Model;
using Bas.RedYarn.WebApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Bas.RedYarn.WebApp.Tests.Services
{
    sealed class TestDataService : IDataService
    {
        private readonly Author firstAuthor = new Author() { Name = "FirstAuthor" };
        private readonly Author secondAuthor = new Author() { Name = "SecondAuthor" };
        private Character firstCharacter = new Character() { Name = "FirstCharacter" };
        private Character secondCharacter = new Character() { Name = "SecondCharacter" };
        private Character thirdCharacter = new Character() { Name = "ThirdCharacter" };
        private Character fourthCharacter = new Character() { Name = "FourthCharacter" };
        private Character fifthCharacter = new Character() { Name = "FifthCharacter" };
        private Character sixthCharacter = new Character() { Name = "SixthCharacter" };
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
            thirdCharacter.RelateTo(fourthCharacter, relationshipFromFirstToSecondName);
            fifthCharacter.RelateTo(sixthCharacter, relationshipFromFirstToSecondName, true);
                                    
            diagram.Authors.Add(firstAuthor);
            diagram.Authors.Add(secondAuthor);
            diagram.Characters.Add(firstCharacter);
            diagram.Characters.Add(secondCharacter);
            diagram.Characters.Add(thirdCharacter);
            diagram.Characters.Add(fourthCharacter);
            diagram.Characters.Add(fifthCharacter);
            diagram.Characters.Add(sixthCharacter);
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
                var firstCharacterModel = new Model.Character(firstCharacter) { Id = Guid.Empty };
                var secondCharacterModel = new Model.Character(secondCharacter) { Id = Guid.Empty };
                var thirdCharacterModel = new Model.Character(thirdCharacter) { Id = Guid.Empty };
                var fourthCharacterModel = new Model.Character(fourthCharacter) { Id = Guid.Empty };
                var fifthCharacterModel = new Model.Character(fifthCharacter) { Id = Guid.Empty };
                var sixthCharacterModel = new Model.Character(sixthCharacter) { Id = Guid.Empty };

                var firstStorylineModel = new Model.Storyline(firstStoryline) { Id = Guid.Empty };
                var secondStorylineModel = new Model.Storyline(secondStoryline) { Id = Guid.Empty };

                var firstRelationship = GetRelationship(firstCharacterModel, secondCharacterModel, relationshipFromFirstToSecondName);
                var secondRelationship = GetRelationship(secondCharacterModel, firstCharacterModel, relationshipFromSecondToFirstName);
                var thirdRelationship = GetRelationship(thirdCharacterModel, fourthCharacterModel, relationshipFromFirstToSecondName);
                var fourthRelationship = GetRelationship(fifthCharacterModel, sixthCharacterModel, relationshipFromFirstToSecondName);
                var firstStorylineConnection = GetStorylineConnection(firstCharacterModel, firstStorylineModel);
                var secondStorylineConnection = GetStorylineConnection(firstCharacterModel, secondStorylineModel);
                var thirdStorylineConnection = GetStorylineConnection(secondCharacterModel, firstStorylineModel);

                var diagramModel = new Model.Diagram(diagram);
                diagramModel.Characters.Add(firstCharacterModel);
                diagramModel.Characters.Add(secondCharacterModel);
                diagramModel.Characters.Add(thirdCharacterModel);
                diagramModel.Characters.Add(fourthCharacterModel);
                diagramModel.Characters.Add(fifthCharacterModel);
                diagramModel.Characters.Add(sixthCharacterModel);
                diagramModel.Storylines.Add(firstStorylineModel);
                diagramModel.Storylines.Add(secondStorylineModel);
                diagramModel.Relationships.Add(secondRelationship);
                diagramModel.Relationships.Add(firstRelationship);                
                diagramModel.Relationships.Add(thirdRelationship);
                diagramModel.Relationships.Add(fourthRelationship);
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