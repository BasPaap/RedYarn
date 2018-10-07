using Bas.RedYarn.WebApp.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bas.RedYarn.WebApp.Tests.Services
{
    sealed class TestDataService : IDataService
    {
        public Author FirstAuthor { get; } = new Author() { Name = "FirstAuthor" };
        public Author SecondAuthor { get; } = new Author() { Name = "SecondAuthor" };
        public Character FirstCharacter { get; } = new Character() { Name = "FirstCharacter" };
        public Character SecondCharacter { get; } = new Character() { Name = "SecondCharacter" };
        public Storyline FirstStoryline { get; } = new Storyline() { Name = "FirstStoryline", Description = "FirstStorylineDescription" };
        public Storyline SecondStoryline { get; } = new Storyline() { Name = "SecondStoryline", Description = "SecondStorylineDescription" };
        public Diagram Diagram { get; } = new Diagram() { Name = "Diagram" };

        public TestDataService()
        {
            FirstCharacter.Aliases.Add("FirstAlias");
            FirstCharacter.Aliases.Add("SecondAlias");
            FirstCharacter.Authors.Add(FirstAuthor);

            SecondCharacter.Authors.Add(FirstAuthor);
            SecondCharacter.Authors.Add(SecondAuthor);

            FirstCharacter.RelateTo(SecondCharacter, "RelationshipFromFirstToSecond", "RelationshipFromSecondToFirst");
            
            Diagram.Authors.Add(FirstAuthor);
            Diagram.Authors.Add(SecondAuthor);
            Diagram.Characters.Add(FirstCharacter);
            Diagram.Characters.Add(SecondCharacter);
            Diagram.Storylines.Add(FirstStoryline);
            Diagram.Storylines.Add(SecondStoryline);
        }

        public Diagram GetDiagram(int id)
        {            
            return Diagram;
        }

        private Model.Character GetCharacterModel(Character character)
        {
            return new Model.Character()
            {
                Name = character.Name,
                Description = character.Description
            };
        }

        private Model.Storyline GetStorylineModel(Storyline storyline)
        {
            return new Model.Storyline()
            {
                Name = storyline.Name,
                Description = storyline.Description
            };
        }

        public Model.Diagram ExpectedModel
        {
            get
            {
                var firstCharacterModel = GetCharacterModel(FirstCharacter);
                firstCharacterModel.Aliases.Add(FirstCharacter.Aliases[0]);
                firstCharacterModel.Aliases.Add(FirstCharacter.Aliases[1]);

                var secondCharacterModel = GetCharacterModel(SecondCharacter);

                var firstStorylineModel = GetStorylineModel(FirstStoryline);
                var secondStorylineModel = GetStorylineModel(FirstStoryline);

                var diagramModel = new Model.Diagram() { Name = Diagram.Name };
                diagramModel.Characters.Add(firstCharacterModel);
                diagramModel.Characters.Add(secondCharacterModel);
                diagramModel.Storylines.Add(firstStorylineModel);
                diagramModel.Storylines.Add(secondStorylineModel);

                return diagramModel;
            }
        }
    }
}
