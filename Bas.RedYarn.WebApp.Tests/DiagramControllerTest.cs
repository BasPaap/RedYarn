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
            
            var stringWriter = new StringWriter();
            var xmlWriter = XmlWriter.Create(stringWriter);
            var xmlSerializer = new XmlSerializer(typeof(T));
            xmlSerializer.Serialize(xmlWriter, objectToSerialize);
            var serializedXml = stringWriter.ToString();
            xmlWriter.Close();

            return serializedXml;
        }

        private static string GetComparableSerialization<T>(T objectToSerialize)
        {
            var uncomparableSerialization = SerializeObject(objectToSerialize);
            const string guidRegexPattern = @"(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}";
            return Regex.Replace(uncomparableSerialization, guidRegexPattern, "GUID", RegexOptions.IgnoreCase);
        }
        
        [TestMethod]
        public void GetDiagram_IdIsValid_ReturnsDiagramJson()
        {
            // Arrange

            // Act
            var result = this.diagramController.GetDiagram(1);

            // Assert
            var expectedSerializedModel = GetComparableSerialization(this.dataService.ExpectedModel);
            var actualSerializedModel = GetComparableSerialization(result.Value);

            Assert.AreNotEqual(0, actualSerializedModel.Length);
            Assert.AreEqual(expectedSerializedModel, actualSerializedModel);
        }
    }
}
