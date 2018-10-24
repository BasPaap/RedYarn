using Bas.RedYarn.WebApp.Database;
using Bas.RedYarn.WebApp.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bas.RedYarn.WebApp.Tests
{
    [TestClass]
    public class DatabaseDataServiceTest : DatabaseDataServiceTestBase
    {
        #region Author
        protected override Author GetTestAuthor()
        {
            return new Author()
            {
                Name = "AuthorName"
            };
        }

        protected override AuthorViewModel GetTestAuthorViewModel()
        {
            return new AuthorViewModel()
            {
                Name = GetTestAuthor().Name
            };
        }

        protected override void AssertAuthor(Author model)
        {
            Assert.AreEqual(GetTestAuthor().Name, model.Name);
        }

        protected override void AssertAuthorViewModel(AuthorViewModel viewModel)
        {
            Assert.AreEqual(GetTestAuthorViewModel().Name, viewModel.Name);
        }
        
        protected override void AssertUpdatedAuthorViewModel(AuthorViewModel viewModel)
        {
            Assert.AreEqual(updatedViewModelName, viewModel.Name);
        }
        #endregion

        #region Character
        protected override (Character model, CharacterNode node) GetTestCharacter()
        {
            var character = new Character()
            {
                Name = "CharacterName",
                Description = "CharacterDescription"
            };

            var characterNode = new CharacterNode()
            {
                Character = character,
                XPosition = 10,
                YPosition = 20
            };

            return (character, characterNode);
        }

        protected override CharacterViewModel GetTestCharacterViewModel()
        {
            var (character, node) = GetTestCharacter();
            return new CharacterViewModel()
            {
                Name = character.Name,
                Description = character.Description,
                XPosition = node.XPosition,
                YPosition = node.YPosition
            };
        }

        protected override void AssertCharacter(Character model, CharacterNode node)
        {
            var (testCharacter, testNode) = GetTestCharacter();

            Assert.AreEqual(testCharacter.Name, model.Name);
            Assert.AreEqual(testCharacter.Description, model.Description);
            Assert.AreEqual(testNode.Character, model);
            Assert.AreEqual(testNode.XPosition, node.XPosition);
            Assert.AreEqual(testNode.YPosition, node.YPosition);
        }

        protected override void AssertCharacterViewModel(CharacterViewModel viewModel)
        {
            var testViewModel = GetTestCharacterViewModel();

            Assert.AreEqual(testViewModel.Name, viewModel.Name);
            Assert.AreEqual(testViewModel.Description, viewModel.Description);
            Assert.AreEqual(testViewModel.XPosition, viewModel.XPosition);
            Assert.AreEqual(testViewModel.YPosition, viewModel.YPosition);
        }

        protected override void AssertUpdatedCharacterViewModel(CharacterViewModel viewModel)
        {
            var testViewModel = GetTestCharacterViewModel();

            Assert.AreEqual(updatedViewModelName, viewModel.Name);
            Assert.AreEqual(testViewModel.Description, viewModel.Description);
            Assert.AreEqual(testViewModel.XPosition, viewModel.XPosition);
            Assert.AreEqual(testViewModel.YPosition, viewModel.YPosition);
        }
        #endregion

        #region Diagram
        protected override Diagram GetTestDiagram()
        {
            return new Diagram()
            {
                Name = "DiagramName"
            };
        }

        protected override DiagramViewModel GetTestDiagramViewModel()
        {
            return new DiagramViewModel()
            {
                Name = GetTestDiagram().Name
            };
        }

        protected override void AssertDiagram(Diagram model)
        {
            Assert.AreEqual(GetTestDiagram().Name, model.Name);
        }

        protected override void AssertDiagramViewModel(DiagramViewModel viewModel)
        {
            Assert.AreEqual(GetTestDiagramViewModel().Name, viewModel.Name);
        }
                
        protected override void AssertUpdatedDiagramViewModel(DiagramViewModel viewModel)
        {
            Assert.AreEqual(updatedViewModelName, viewModel.Name);
        }
        #endregion

        #region Storyline
        protected override (Storyline model, StorylineNode node) GetTestStoryline()
        {
            var storyline = new Storyline()
            {
                Name = "StorylineName",
                Description = "StorylineDescription"
            };

            var node = new StorylineNode()
            {
                Storyline = storyline,
                XPosition = 10,
                YPosition = 20
            };

            return (storyline, node);
        }

        protected override StorylineViewModel GetTestStorylineViewModel()
        {
            var (storyline, node) = GetTestStoryline();
            return new StorylineViewModel()
            {
                Name = storyline.Name,
                Description = storyline.Description,
                XPosition = node.XPosition,
                YPosition = node.YPosition
            };
        }

        protected override void AssertStoryline(Storyline model, StorylineNode node)
        {
            var (testStoryline, testNode) = GetTestStoryline();
            Assert.AreEqual(testStoryline.Name, model.Name);
            Assert.AreEqual(testStoryline.Description, model.Description);
            Assert.AreEqual(testNode.Storyline, node.Storyline);
            Assert.AreEqual(testNode.XPosition, node.XPosition);
            Assert.AreEqual(testNode.YPosition, node.YPosition);
        }

        protected override void AssertStorylineViewModel(StorylineViewModel viewModel)
        {
            var testStorylineViewModel = GetTestStorylineViewModel();
            Assert.AreEqual(testStorylineViewModel.Name, viewModel.Name);
            Assert.AreEqual(testStorylineViewModel.Description, viewModel.Description);
            Assert.AreEqual(testStorylineViewModel.XPosition, viewModel.XPosition);
            Assert.AreEqual(testStorylineViewModel.YPosition, viewModel.YPosition);
        }

        protected override void AssertUpdatedStorylineViewModel(StorylineViewModel viewModel)
        {
            var testStorylineViewModel = GetTestStorylineViewModel();
            Assert.AreEqual(updatedViewModelName, viewModel.Name);
            Assert.AreEqual(testStorylineViewModel.Description, viewModel.Description);
            Assert.AreEqual(testStorylineViewModel.XPosition, viewModel.XPosition);
            Assert.AreEqual(testStorylineViewModel.YPosition, viewModel.YPosition);
        }
        #endregion
    }
}
