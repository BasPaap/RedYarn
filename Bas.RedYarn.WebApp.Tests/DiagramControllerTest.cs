using Bas.RedYarn.WebApp.Controllers;
using Bas.RedYarn.WebApp.Services;
using Bas.RedYarn.WebApp.Tests.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;

namespace Bas.RedYarn.WebApp.Tests
{
    [TestClass]
    public class DiagramControllerTest
    {
        private readonly TestDataService dataService = new TestDataService();
        private DiagramController diagramController;

        [TestInitialize]
        public void Initialize()
        {
            this.diagramController = new DiagramController(dataService);
        }

        private static string SerializeObject<T>(T objectToSerialize)
        {
            if (objectToSerialize == null)
            {
                return string.Empty;
            }

            try
            {
                var stringWriter = new StringWriter();
                var xmlWriter = XmlWriter.Create(stringWriter);
                var xmlSerializer = new XmlSerializer(typeof(T));
                xmlSerializer.Serialize(xmlWriter, objectToSerialize);
                var serializedXml = stringWriter.ToString();
                xmlWriter.Close();

                return serializedXml;
            }
            catch 
            {
                return string.Empty;
            }
        }

        private static string GetComparableSerialization<T>(T objectToSerialize)
        {
            var uncomparableSerialization = SerializeObject(objectToSerialize);

            const string guidRegexPattern = @"^[{(]?[0-9A-F]{8}[-]?(?:[0-9A-F]{4}[-]?){3}[0-9A-F]{12}[)}]?$";
            return Regex.Replace(uncomparableSerialization, guidRegexPattern, "GUID", RegexOptions.IgnoreCase);
        }


        [TestMethod]
        public void GetDiagram_IdIsValid_ReturnsDiagramJson()
        {
            // Arrange
            
            // Act
            var result = this.diagramController.GetDiagram(1);
            
            // Assert
            Assert.AreEqual(GetComparableSerialization(this.dataService.ExpectedModel), GetComparableSerialization(result.Value));
        }
    }
}
