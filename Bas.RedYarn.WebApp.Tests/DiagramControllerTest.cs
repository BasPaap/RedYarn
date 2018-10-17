using Bas.RedYarn.WebApp.Tests.Extensions;
using Bas.RedYarn.WebApp.Tests.Helpers;
using Bas.RedYarn.WebApp.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Bas.RedYarn.WebApp.Tests
{
    [TestClass]
    public partial class DiagramControllerTest
    {
        //[TestMethod]
        //public void DiagramCreate_WithInvalidModel_Returns400BadRequest()
        //{
        //    // Arrange
        //    var httpClient = TestServerHelper.GetTestClient(this.dataService);
            
        //    // Act
        //    var result = (httpClient.PostAsync("api/Diagram", (new DiagramViewModel()).ToJsonStringContent())).Result;

        //    // Assert          
        //    Assert.AreEqual(System.Net.HttpStatusCode..BadRequest, result.StatusCode);
        //}

        //[TestMethod]
        //public void DiagramCreate_WithoutContent_Returns400BadRequest()
        //{
        //    // Arrange
        //    var httpClient = TestServerHelper.GetTestClient(this.dataService);

        //    // Act
        //    var result = (httpClient.PostAsync("api/Diagram", null)).Result;

        //    // Assert          
        //    Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, result.StatusCode);
        //}

        // UpdateDiagram
        // arg null -> 400 bad request
        // id bestaat niet -> 404 not found
        // vm is okee -> 204 no content (https://stackoverflow.com/questions/797834/should-a-restful-put-operation-return-something)

        // CreateDiagram
        // arg null -> 400 bad request
        // model okee -> 201 Created met Uri naar GetDiagram(nieuw id)

        // DeleteDiagram
        // id bestaat niet -> 404 not found
        // id bestaat -> 204 no content

        public void AssertCreatedDiagram(DiagramViewModel diagram)
        {            
            //Assert.AreEqual(0, diagram.CharacterPlotElementConnections.Count);
            //Assert.AreEqual(6, diagram.Characters.Count);
            //Assert.IsTrue(diagram.Characters.Select(c => c.Name).Contains("FirstCharacter"));
            //Assert.IsTrue(diagram.Characters.Select(c => c.Name).Contains("SecondCharacter"));
            //Assert.IsTrue(diagram.Characters.Select(c => c.Name).Contains("ThirdCharacter"));
            //Assert.IsTrue(diagram.Characters.Select(c => c.Name).Contains("FourthCharacter"));
            //Assert.IsTrue(diagram.Characters.Select(c => c.Name).Contains("FifthCharacter"));
            //Assert.IsTrue(diagram.Characters.Select(c => c.Name).Contains("SixthCharacter"));
            //Assert.AreEqual("Diagram", diagram.Name);
            //Assert.AreEqual(0, diagram.PlotElements.Count);
            //Assert.AreEqual(4, diagram.Relationships.Count);
            //Assert.IsTrue(diagram.Relationships.Select(r => r.Name).Contains("RelationshipFromFirstToSecond"));
            //Assert.IsTrue(diagram.Relationships.Select(r => r.Name).Contains("RelationshipFromSecondToFirst"));
            //Assert.IsTrue(diagram.Relationships.Select(r => r.Name).Contains("RelationshipFromThirdToFourth"));
            //Assert.IsTrue(diagram.Relationships.Select(r => r.Name).Contains("RelationshipFromFifthToSixth"));
            //Assert.AreEqual(3, diagram.StorylineCharacterConnections.Count);
            //Assert.AreEqual(0, diagram.StorylinePlotElementConnections.Count);
            //Assert.AreEqual(2, diagram.Storylines.Count);
            //Assert.IsTrue(diagram.Storylines.Select(s => s.Name).Contains("FirstStoryline"));
            //Assert.IsTrue(diagram.Storylines.Select(s => s.Name).Contains("SecondStoryline"));
        }
    }
}
