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

        #region Alias
        protected override Alias GetTestAlias()
        {
            return new Alias()
            {
                Name = "AliasName"
            };
        }

        protected override void AssertAlias(Alias model)
        {
            Assert.AreEqual(GetTestAlias().Name, model.Name);
        }

        protected override AliasViewModel GetTestAliasViewModel()
        {
            return new AliasViewModel(GetTestAlias());
        }

        protected override AliasViewModel GetUpdatedAliasViewModel()
        {
            var viewModel = GetTestAliasViewModel();
            viewModel.Name = updatedName;
            return viewModel;
        }

        protected override void AssertAliasViewModel(AliasViewModel viewModel)
        {
            Assert.AreEqual(GetTestAliasViewModel().Name, viewModel.Name);
        }

        protected override void AssertUpdatedAliasViewModel(AliasViewModel viewModel)
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

        #region Tag
        protected override Tag GetTestTag()
        {
            return new Tag()
            {
                Name = "TagName",
                Category = "TagCategory"
            };
        }

        protected override TagViewModel GetTestTagViewModel()
        {
            return new TagViewModel(GetTestTag());
        }

        protected override void AssertTag(Tag model)
        {
            var testTag = GetTestTag();
            Assert.AreEqual(testTag.Name, model.Name);
            Assert.AreEqual(testTag.Category, model.Category);
        }

        protected override void AssertTagViewModel(TagViewModel viewModel)
        {
            var testTagViewModel = GetTestTagViewModel();
            Assert.AreEqual(testTagViewModel.Name, viewModel.Name);
            Assert.AreEqual(testTagViewModel.Category, viewModel.Category);
        }

        protected override TagViewModel GetUpdatedTagViewModel()
        {
            var viewModel = GetTestTagViewModel();
            viewModel.Name = updatedName;
            return viewModel;
        }

        protected override void AssertUpdatedTagViewModel(TagViewModel viewModel)
        {
            Assert.AreEqual(updatedName, viewModel.Name);
        }

        #endregion

        #region Relationship
        protected override Relationship GetTestRelationship()
        {
            var firstCharacter = new Character()
            {
                Name = "FirstCharacter"
            };

            var secondCharacter = new Character()
            {
                Name = "SecondCharacter"
            };

            return new Relationship()
            {
                FirstCharacter = firstCharacter,
                SecondCharacter = secondCharacter,
                Name = "RelationshipName",
                IsDirectional = true
            };
        }

        protected override RelationshipViewModel GetTestRelationshipViewModel(Func<(Guid, Guid)> getNodeIdsFunc)
        {
            return new RelationshipViewModel(GetTestRelationship(), null, getNodeIdsFunc);
        }

        protected override RelationshipViewModel GetUpdatedRelationshipViewModel(Func<(Guid, Guid)> getNodeIdsFunc)
        {
            var relationshipViewModel = GetTestRelationshipViewModel(getNodeIdsFunc);
            relationshipViewModel.Name = updatedName;
            return relationshipViewModel;
        }

        protected override void AssertRelationship(Relationship model)
        {
            var testRelationship = GetTestRelationship();
            Assert.AreEqual(testRelationship.Name, model.Name);
            Assert.AreEqual(testRelationship.IsDirectional, model.IsDirectional);
        }

        protected override void AssertRelationshipViewModel(RelationshipViewModel viewModel)
        {
            var testRelationshipViewModel = GetTestRelationshipViewModel(null);
            Assert.AreEqual(testRelationshipViewModel.Name, viewModel.Name);
            Assert.AreEqual(testRelationshipViewModel.IsDirectional, viewModel.IsDirectional);
        }

        protected override void AssertUpdatedRelationshipViewModel(RelationshipViewModel viewModel)
        {
            Assert.AreEqual(updatedName, viewModel.Name);
        }
        #endregion

        #region CharacterPlotElement

        protected override CharacterPlotElementJoinTable GetTestCharacterPlotElementConnection()
        {
            var characterPlotElementConnection = new CharacterPlotElementJoinTable()
            {
                CharacterOwnsPlotElement = true,
                LeftEntity = new Character()
                {
                    Name = "Character"
                },
                RightEntity = new PlotElement()
                {
                    Name = "PlotElement"
                }
            };

            return characterPlotElementConnection;
        }

        protected override void AssertCharacterPlotElementConnection(CharacterPlotElementJoinTable model)
        {
            Assert.IsTrue(model.CharacterOwnsPlotElement);
            Assert.AreNotEqual(Guid.Empty, model.LeftEntityId);
            Assert.AreNotEqual(Guid.Empty, model.RightEntityId);
            Assert.AreEqual(GetTestCharacterPlotElementConnection().LeftEntity.Name, model.LeftEntity.Name);
            Assert.AreEqual(GetTestCharacterPlotElementConnection().RightEntity.Name, model.RightEntity.Name);
        }


        protected override CharacterPlotElementConnectionViewModel GetTestCharacterPlotElementConnectionViewModel(Func<(Guid, Guid)> getNodeIdsFunc)
        {
            return new CharacterPlotElementConnectionViewModel(getNodeIdsFunc)
            {
                CharacterOwnsPlotElement = true
            };
        }

        protected override CharacterPlotElementConnectionViewModel GetUpdatedCharacterPlotElementConnectionViewModel(Func<(Guid, Guid)> getNodeIdsFunc)
        {
            var viewmodel = GetTestCharacterPlotElementConnectionViewModel(getNodeIdsFunc);
            viewmodel.CharacterOwnsPlotElement = false;

            return viewmodel;
        }

        protected override void AssertCharacterPlotElementConnectionViewModel(CharacterPlotElementConnectionViewModel viewModel)
        {
            Assert.IsTrue(viewModel.CharacterOwnsPlotElement);
            Assert.AreNotEqual(Guid.Empty, viewModel.FromNodeId);
            Assert.AreNotEqual(Guid.Empty, viewModel.ToNodeId);
        }

        protected override void AssertUpdatedCharacterPlotElementConnectionViewModel(CharacterPlotElementConnectionViewModel viewModel)
        {
            Assert.IsFalse(viewModel.CharacterOwnsPlotElement);
            Assert.AreNotEqual(Guid.Empty, viewModel.FromNodeId);
            Assert.AreNotEqual(Guid.Empty, viewModel.ToNodeId);
        }

        #endregion

        #region StorylineCharacter
        protected override JoinTable<Storyline, Character> GetTestStorylineCharacterConnection()
        {
            return new JoinTable<Storyline, Character>()
            {
                LeftEntity = new Storyline()
                {
                    Name = "Storyline"
                },
                RightEntity = new Character()
                {
                    Name = "Character"
                }
            };
        }

        protected override void AssertStorylineCharacterConnection(JoinTable<Storyline, Character> model)
        {
            Assert.AreNotEqual(Guid.Empty, model.LeftEntityId);
            Assert.AreNotEqual(Guid.Empty, model.RightEntityId);
            Assert.AreEqual(GetTestStorylineCharacterConnection().LeftEntity.Name, model.LeftEntity.Name);
            Assert.AreEqual(GetTestStorylineCharacterConnection().RightEntity.Name, model.RightEntity.Name);
        }

        protected override StorylineCharacterConnectionViewModel GetTestStorylineCharacterConnectionViewModel(Func<(Guid, Guid)> getNodeIdsFunc)
        {
            return new StorylineCharacterConnectionViewModel(getNodeIdsFunc);
        }

        protected override StorylineCharacterConnectionViewModel GetUpdatedStorylineCharacterConnectionViewModel(Func<(Guid, Guid)> getNodeIdsFunc)
        {
            return new StorylineCharacterConnectionViewModel(getNodeIdsFunc);
        }

        protected override void AssertStorylineCharacterConnectionViewModel(StorylineCharacterConnectionViewModel viewModel)
        {
            Assert.AreNotEqual(Guid.Empty, viewModel.FromNodeId);
            Assert.AreNotEqual(Guid.Empty, viewModel.ToNodeId);
        }

        protected override void AssertUpdatedStorylineCharacterConnectionViewModel(StorylineCharacterConnectionViewModel viewModel)
        {
            Assert.AreNotEqual(Guid.Empty, viewModel.FromNodeId);
            Assert.AreNotEqual(Guid.Empty, viewModel.ToNodeId);
        }
        #endregion

        #region StorylinePlotElement
        protected override JoinTable<Storyline, PlotElement> GetTestStorylinePlotElementConnection()
        {
            return new JoinTable<Storyline, PlotElement>()
            {
                LeftEntity = new Storyline()
                {
                    Name = "Storyline"
                },
                RightEntity = new PlotElement()
                {
                    Name = "PlotElement"
                }
            };
        }

        protected override void AssertStorylinePlotElementConnection(JoinTable<Storyline, PlotElement> model)
        {            
            Assert.AreNotEqual(Guid.Empty, model.LeftEntityId);
            Assert.AreNotEqual(Guid.Empty, model.RightEntityId);
            Assert.AreEqual(GetTestStorylinePlotElementConnection().LeftEntity.Name, model.LeftEntity.Name);
            Assert.AreEqual(GetTestStorylinePlotElementConnection().RightEntity.Name, model.RightEntity.Name);
        }

        protected override StorylinePlotElementConnectionViewModel GetTestStorylinePlotElementConnectionViewModel(Func<(Guid, Guid)> getNodeIdsFunc)
        {
            return new StorylinePlotElementConnectionViewModel(getNodeIdsFunc);
        }

        protected override StorylinePlotElementConnectionViewModel GetUpdatedStorylinePlotElementConnectionViewModel(Func<(Guid, Guid)> getNodeIdsFunc)
        {
            return new StorylinePlotElementConnectionViewModel(getNodeIdsFunc);
        }

        protected override void AssertStorylinePlotElementConnectionViewModel(StorylinePlotElementConnectionViewModel viewModel)
        {
            Assert.AreNotEqual(Guid.Empty, viewModel.FromNodeId);
            Assert.AreNotEqual(Guid.Empty, viewModel.ToNodeId);
        }

        protected override void AssertUpdatedStorylinePlotElementConnectionViewModel(StorylinePlotElementConnectionViewModel viewModel)
        {
            Assert.AreNotEqual(Guid.Empty, viewModel.FromNodeId);
            Assert.AreNotEqual(Guid.Empty, viewModel.ToNodeId);
        }
        
        #endregion
    }
}
