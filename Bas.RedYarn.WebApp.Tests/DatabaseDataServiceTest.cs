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
        protected override void AssertAuthorViewModel(AuthorViewModel authorViewModel)
        {
            throw new NotImplementedException();
        }

        protected override void AssertCharacterViewModel(CharacterViewModel characterViewModel)
        {
            throw new NotImplementedException();
        }

        protected override void AssertDiagramViewModel(DiagramViewModel diagramViewModel)
        {
            throw new NotImplementedException();
        }

        protected override void AssertStorylineViewModel(StorylineViewModel storylineViewModel)
        {
            throw new NotImplementedException();
        }

        protected override Author GetTestAuthor()
        {
            throw new NotImplementedException();
        }

        protected override (Character model, CharacterNode node) GetTestCharacter()
        {
            throw new NotImplementedException();
        }

        protected override Diagram GetTestDiagram()
        {
            throw new NotImplementedException();
        }

        protected override (Storyline model, StorylineNode node) GetTestStoryline()
        {
            throw new NotImplementedException();
        }
    }
}
