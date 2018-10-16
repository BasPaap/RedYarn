using Bas.RedYarn.WebApp.ViewModels;
using Bas.RedYarn.WebApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Bas.RedYarn.WebApp.Tests.Services
{
    sealed class TestDataService : IDataService
    {
        private readonly Author firstAuthor = new Author() { Name = "FirstAuthor" };
        private readonly Author secondAuthor = new Author() { Name = "SecondAuthor" };
        private Character firstCharacter = new Character() { Name = "FirstCharacter" };
        private Character secondCharacter = new Character() { Name = "SecondCharacter" };
        private Character thirdCharacter = new Character() { Name = "ThirdCharacter" };
        private readonly Character fourthCharacter = new Character() { Name = "FourthCharacter" };
        private Character fifthCharacter = new Character() { Name = "FifthCharacter" };
        private readonly Character sixthCharacter = new Character() { Name = "SixthCharacter" };
        private readonly Storyline firstStoryline = new Storyline() { Name = "FirstStoryline", Description = "FirstStorylineDescription" };
        private readonly Storyline secondStoryline = new Storyline() { Name = "SecondStoryline", Description = "SecondStorylineDescription" };
        private Diagram diagram = new Diagram() { Name = "Diagram" };

        private const string relationshipFromFirstToSecondName = "RelationshipFromFirstToSecond";
        private const string relationshipFromSecondToFirstName = "RelationshipFromSecondToFirst";
        private const string relationshipFromThirdToFourth = "RelationshipFromThirdToFourth";
        private const string relationshipFromFifthToSixth = "RelationshipFromFifthToSixth";

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
            thirdCharacter.RelateTo(fourthCharacter, relationshipFromThirdToFourth);
            fifthCharacter.RelateTo(sixthCharacter, relationshipFromFifthToSixth, true);
                                    
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
        
        public DiagramViewModel GetDiagramViewModel(Guid id)
        {            
            return new DiagramViewModel(this.diagram);
        }

        public ViewModels.DiagramViewModel ExpectedModel
        {
            get
            {
                var firstCharacterModel = new ViewModels.CharacterViewModel(firstCharacter) { Id = Guid.Empty };
                var secondCharacterModel = new ViewModels.CharacterViewModel(secondCharacter) { Id = Guid.Empty };
                var thirdCharacterModel = new ViewModels.CharacterViewModel(thirdCharacter) { Id = Guid.Empty };
                var fourthCharacterModel = new ViewModels.CharacterViewModel(fourthCharacter) { Id = Guid.Empty };
                var fifthCharacterModel = new ViewModels.CharacterViewModel(fifthCharacter) { Id = Guid.Empty };
                var sixthCharacterModel = new ViewModels.CharacterViewModel(sixthCharacter) { Id = Guid.Empty };

                var firstStorylineModel = new ViewModels.StorylineViewModel(firstStoryline) { Id = Guid.Empty };
                var secondStorylineModel = new ViewModels.StorylineViewModel(secondStoryline) { Id = Guid.Empty };

                var firstRelationship = GetRelationship(firstCharacterModel, secondCharacterModel, relationshipFromFirstToSecondName);
                var secondRelationship = GetRelationship(secondCharacterModel, firstCharacterModel, relationshipFromSecondToFirstName);
                var thirdRelationship = GetRelationship(thirdCharacterModel, fourthCharacterModel, relationshipFromFirstToSecondName);
                var fourthRelationship = GetRelationship(fifthCharacterModel, sixthCharacterModel, relationshipFromFirstToSecondName);
                var firstStorylineConnection = GetStorylineConnection(firstCharacterModel, firstStorylineModel);
                var secondStorylineConnection = GetStorylineConnection(firstCharacterModel, secondStorylineModel);
                var thirdStorylineConnection = GetStorylineConnection(secondCharacterModel, firstStorylineModel);

                var diagramModel = new ViewModels.DiagramViewModel(diagram);
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
                diagramModel.StorylineCharacterConnections.Add(firstStorylineConnection);
                diagramModel.StorylineCharacterConnections.Add(secondStorylineConnection);
                diagramModel.StorylineCharacterConnections.Add(thirdStorylineConnection);

                return diagramModel;
            }
        }

        private ViewModels.RelationshipViewModel GetRelationship(ViewModels.CharacterViewModel firstCharacterModel, ViewModels.CharacterViewModel secondCharacterModel, string name)
        {
            return new ViewModels.RelationshipViewModel()
            {
                FromCharacterId = firstCharacterModel.Id,
                ToCharacterId = secondCharacterModel.Id,
                Name = name
            };
        }

        private ViewModels.StorylineConnectionViewModel GetStorylineConnection(ViewModels.CharacterViewModel characterModel, ViewModels.StorylineViewModel storylineModel)
        {
            return new ViewModels.StorylineConnectionViewModel()
            {
                ConnectionId = characterModel.Id,
                StorylineId = storylineModel.Id
            };
        }

        public Task<DiagramViewModel> CreateDiagramAsync(string name)
        {
            throw new NotImplementedException();
        }

        public void AddCharacter(Guid diagramId, CharacterViewModel characterViewModel)
        {
            throw new NotImplementedException();
        }

        public void AddStoryline(Guid diagramId, StorylineViewModel storylineViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
