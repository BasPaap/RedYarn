using Bas.RedYarn.WebApp.Controllers;
using Bas.RedYarn.WebApp.Services;
using Bas.RedYarn.WebApp.Tests.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bas.RedYarn.WebApp.Tests
{
    [TestClass]
    public class DiagramControllerTest
    {
        private IDataService dataService = new TestDataService();
        private DiagramController diagramController;

        [TestInitialize]
        public void Initialize()
        {
            this.diagramController = new DiagramController(dataService);
        }

        [TestMethod]
        public void GetDiagram_IdIsValid_ReturnsDiagramJson()
        {
            // Arrange
            var expectedResult = "test";

            // Act
            var result = this.diagramController.GetDiagram(1);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
