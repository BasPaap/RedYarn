using Bas.RedYarn.WebApp.Tests.Extensions;
using Bas.RedYarn.WebApp.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Bas.RedYarn.WebApp.Tests
{
    public partial class CharacterControllerTest
    {
        private const string relationshipName = "RelationshipName";
        private const string characterViewModelName = "CharacterViewModel";

        [TestMethod]
        public void RelateTo_ArgumentsAreOk_CreatesRelationshipAndReturns201Created()
        {
            // Arrange
            var characterViewModel = new CharacterViewModel()
            {
                Name = characterViewModelName
            };
            this.dataService.CharacterViewModels.Add(characterViewModel);

            var secondCharacterViewModel = new CharacterViewModel()
            {
                Name = "Second" + characterViewModelName
            };
            this.dataService.CharacterViewModels.Add(secondCharacterViewModel);

            var relationship = (relationshipName, true);

            // Act
            var result = httpClient.PostAsync($"api/Character/{characterViewModel.Id}/relateto/{secondCharacterViewModel.Id}", relationship.ToJsonStringContent()).Result;

            // Assert
            var content = result.Content.FromJsonString<RelationshipViewModel>();
            Assert.IsNotNull(result);
            Assert.IsNotNull(content);
            Assert.AreEqual(System.Net.HttpStatusCode.Created, result.StatusCode);
            Assert.AreEqual($"/api/Character/{content.FromCharacterId.ToString()}", result.Headers.Location.PathAndQuery);
            Assert.AreEqual(characterViewModel.Id, content.FromCharacterId);
            Assert.AreEqual(secondCharacterViewModel.Id, content.ToCharacterId);
            Assert.AreEqual(relationshipName, content.Name);
            Assert.IsTrue(content.IsDirectional);
        }

        [TestMethod]
        public void RelateTo_WithUnknownFromId_Returns404NotFound()
        {
            // Arrange
            var characterViewModel = new CharacterViewModel()
            {
                Name = "CharacterViewModel"
            };

            this.dataService.CharacterViewModels.Add(characterViewModel);
            var relationship = (relationshipName, true);

            // Act
            var result = httpClient.PostAsync($"api/Character/{Guid.NewGuid().ToString()}/relateto/{characterViewModel.Id}", relationship.ToJsonStringContent()).Result;

            // Assert
            Assert.AreEqual(System.Net.HttpStatusCode.NotFound, result.StatusCode);
        }

        [TestMethod]
        public void RelateTo_WithUnknownToId_Returns404NotFound()
        {
            // Arrange
            var characterViewModel = new CharacterViewModel()
            {
                Name = "CharacterViewModel"
            };

            this.dataService.CharacterViewModels.Add(characterViewModel);
            var relationship = (relationshipName, true);

            // Act
            var result = httpClient.PostAsync($"api/Character/{characterViewModel.Id}/relateto/{Guid.NewGuid().ToString()}", relationship.ToJsonStringContent()).Result;

            // Assert
            Assert.AreEqual(System.Net.HttpStatusCode.NotFound, result.StatusCode);
        }

        [TestMethod]
        public void RelateTo_WithEmptyName_Returns400BadRequest()
        {
            // Arrange
            var characterViewModel = new CharacterViewModel()
            {
                Name = "CharacterViewModel"
            };
            this.dataService.CharacterViewModels.Add(characterViewModel);

            var secondCharacterViewModel = new CharacterViewModel()
            {
                Name = "SecondCharacterViewModel"
            };
            this.dataService.CharacterViewModels.Add(secondCharacterViewModel);
            var relationship = (string.Empty, true);

            // Act
            var result = (httpClient.PostAsync($"api/Character/{characterViewModel.Id}/relateto/{secondCharacterViewModel.Id}", relationship.ToJsonStringContent())).Result;

            // Assert
            Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, result.StatusCode);
        }
    }
}
