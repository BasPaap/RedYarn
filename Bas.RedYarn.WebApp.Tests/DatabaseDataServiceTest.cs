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
        private const string updatedName = "UpdatedName";
        private const string updatedDescription = "UpdatedDescription";
        private const float updatedXPosition = 50.0f;
        private const float updatedYPosition = 60.0f;

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
            return new AuthorViewModel(GetTestAuthor());
        }

        protected override void AssertAuthor(Author model)
        {
            Assert.AreEqual(GetTestAuthor().Name, model.Name);
        }

        protected override void AssertAuthorViewModel(AuthorViewModel viewModel)
        {
            Assert.AreEqual(GetTestAuthorViewModel().Name, viewModel.Name);
        }

        protected override AuthorViewModel GetUpdatedAuthorViewModel()
        {
            var viewModel = GetTestAuthorViewModel();
            viewModel.Name = updatedName;
            return viewModel;
        }

        protected override void AssertUpdatedAuthorViewModel(AuthorViewModel viewModel)
        {
            Assert.AreEqual(updatedName, viewModel.Name);
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
            return new CharacterViewModel(character, node.XPosition, node.YPosition);
        }

        protected override void AssertCharacter(Character model, CharacterNode node)
        {
            var (testCharacter, testNode) = GetTestCharacter();
            AssertPropertiesAreEqual(testCharacter, model, nameof(model.Name), 
                                                           nameof(model.Description));
            AssertPropertiesAreEqual(testNode, node, nameof(node.XPosition), 
                                                     nameof(node.YPosition));                                    
        }
        
        protected override void AssertCharacterViewModel(CharacterViewModel viewModel)
        {
            var testViewModel = GetTestCharacterViewModel();
            AssertPropertiesAreEqual(testViewModel, viewModel, nameof(viewModel.Name),
                                                               nameof(viewModel.Description),
                                                               nameof(viewModel.XPosition),
                                                               nameof(viewModel.YPosition));            
        }

        protected override CharacterViewModel GetUpdatedCharacterViewModel()
        {
            var viewModel = GetTestCharacterViewModel();
            viewModel.Name = updatedName;
            viewModel.Description = updatedDescription;
            viewModel.XPosition = updatedXPosition;
            viewModel.YPosition = updatedYPosition;
            return viewModel;
        }

        protected override void AssertUpdatedCharacterViewModel(CharacterViewModel viewModel)
        {
            Assert.AreEqual(updatedName, viewModel.Name);
            Assert.AreEqual(updatedDescription, viewModel.Description);
            Assert.AreEqual(updatedXPosition, viewModel.XPosition);
            Assert.AreEqual(updatedYPosition, viewModel.YPosition);
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
            return new DiagramViewModel(GetTestDiagram());
        }

        protected override void AssertDiagram(Diagram model)
        {
            Assert.AreEqual(GetTestDiagram().Name, model.Name);
        }

        protected override void AssertDiagramViewModel(DiagramViewModel viewModel)
        {
            Assert.AreEqual(GetTestDiagramViewModel().Name, viewModel.Name);
            Assert.AreNotEqual(Guid.Empty, viewModel.Id);
        }

        protected override DiagramViewModel GetUpdatedDiagramViewModel()
        {
            var viewModel = GetTestDiagramViewModel();
            viewModel.Name = updatedName;
            return viewModel;
        }

        protected override void AssertUpdatedDiagramViewModel(DiagramViewModel viewModel)
        {
            Assert.AreEqual(updatedName, viewModel.Name);
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
            return new StorylineViewModel(storyline, node.XPosition, node.YPosition);            
        }

        protected override void AssertStoryline(Storyline model, StorylineNode node)
        {
            var (testStoryline, testNode) = GetTestStoryline();
            AssertPropertiesAreEqual(testStoryline, model, nameof(model.Name),
                                                           nameof(model.Description));
            AssertPropertiesAreEqual(testNode, node, nameof(node.XPosition),
                                                     nameof(node.YPosition));
        }

        protected override void AssertStorylineViewModel(StorylineViewModel viewModel)
        {
            var testStorylineViewModel = GetTestStorylineViewModel();
            AssertPropertiesAreEqual(testStorylineViewModel, viewModel, nameof(viewModel.Name),
                                                                        nameof(viewModel.Description),
                                                                        nameof(viewModel.XPosition),
                                                                        nameof(viewModel.YPosition));
        }

        protected override StorylineViewModel GetUpdatedStorylineViewModel()
        {
            var viewModel = GetTestStorylineViewModel();
            viewModel.Name = updatedName;
            viewModel.Description = updatedDescription;
            viewModel.XPosition = updatedXPosition;
            viewModel.YPosition = updatedYPosition;
            return viewModel;
        }

        protected override void AssertUpdatedStorylineViewModel(StorylineViewModel viewModel)
        {
            var testStorylineViewModel = GetTestStorylineViewModel();
            Assert.AreEqual(updatedName, viewModel.Name);
            Assert.AreEqual(updatedDescription, viewModel.Description);
            Assert.AreEqual(updatedXPosition, viewModel.XPosition);
            Assert.AreEqual(updatedYPosition, viewModel.YPosition);
        }

        #endregion

        #region PlotElement
        protected override (PlotElement model, PlotElementNode node) GetTestPlotElement()
        {
            var plotElement = new PlotElement()
            {
                Name = "PlotElementName",
                Description = "PlotElementDescription"
            };

            var node = new PlotElementNode()
            {
                PlotElement = plotElement,
                XPosition = 10,
                YPosition = 20
            };

            return (plotElement, node);
        }

        protected override PlotElementViewModel GetTestPlotElementViewModel()
        {
            var (plotElement, node) = GetTestPlotElement();
            return new PlotElementViewModel(plotElement, node.XPosition, node.YPosition);
        }

        protected override void AssertPlotElement(PlotElement model, PlotElementNode node)
        {
            var (testPlotElement, testNode) = GetTestPlotElement();
            AssertPropertiesAreEqual(testPlotElement, model, nameof(model.Name),
                                                           nameof(model.Description));
            AssertPropertiesAreEqual(testNode, node, nameof(node.XPosition),
                                                     nameof(node.YPosition));
        }

        protected override void AssertPlotElementViewModel(PlotElementViewModel viewModel)
        {
            var testPlotElementViewModel = GetTestPlotElementViewModel();
            AssertPropertiesAreEqual(testPlotElementViewModel, viewModel, nameof(viewModel.Name),
                                                                        nameof(viewModel.Description),
                                                                        nameof(viewModel.XPosition),
                                                                        nameof(viewModel.YPosition));
        }

        
        protected override PlotElementViewModel GetUpdatedPlotElementViewModel()
        {
            var viewModel = GetTestPlotElementViewModel();
            viewModel.Name = updatedName;
            viewModel.Description = updatedDescription;
            viewModel.XPosition = updatedXPosition;
            viewModel.YPosition = updatedYPosition;
            return viewModel;
        }


        protected override void AssertUpdatedPlotElementViewModel(PlotElementViewModel viewModel)
        {
            var testPlotElementViewModel = GetTestPlotElementViewModel();
            Assert.AreEqual(updatedName, viewModel.Name);
            Assert.AreEqual(updatedDescription, viewModel.Description);
            Assert.AreEqual(updatedXPosition, viewModel.XPosition);
            Assert.AreEqual(updatedYPosition, viewModel.YPosition);
        }
        #endregion
    }
}
