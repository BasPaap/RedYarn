using Bas.RedYarn.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bas.RedYarn
{
    [TestClass]
    public class CharacterTest
    {
        private Character character;

        [TestInitialize]
        public void Initialize()
        {
            character = new Character();
        }
                
        [TestMethod]
        public void ToString_NameIsNotEmpty_ReturnsName()
        {
            ToStringHelper.ToString_NameIsNotEmpty_ReturnsName(this.character);
        }

        [TestMethod]
        public void ToString_NameIsEmpty_ReturnsClassName()
        {
            ToStringHelper.ToString_NameIsEmpty_ReturnsClassName(this.character);
        }
                
        [TestMethod]
        public void StorylinesAdd_NewStoryline_StorylineContainsCharacter()
        {
            // Arrange
            var storyline = new Storyline() { Name = "Storyline" };

            // Act
            this.character.Storylines.Add(storyline);
            
            // Assert          
            Assert.AreSame(this.character, storyline.Characters[0]);            
        }

        [TestMethod]
        public void StorylinesInsert_NewStoryline_StorylineContainsCharacter()
        {
            // Arrange
            var storyline = new Storyline() { Name = "Storyline" };

            // Act
            this.character.Storylines.Insert(0, storyline);

            // Assert          
            Assert.AreSame(this.character, storyline.Characters[0]);
        }

        [TestMethod]
        public void StorylinesClear_StorylineContainsCharacter_CharacterIsRemovedFromStoryline()
        {
            // Arrange
            var storyline = new Storyline() { Name = "Storyline" };
            this.character.Storylines.Add(storyline);

            // Act
            this.character.Storylines.Clear();

            // Assert          
            Assert.AreEqual(0, storyline.Characters.Count);
        }

        [TestMethod]
        public void StorylinesRemove_StorylineContainsCharacter_CharacterIsRemovedFromStoryline()
        {
            // Arrange
            var storyline = new Storyline() { Name = "Storyline" };
            this.character.Storylines.Add(storyline);

            // Act
            this.character.Storylines.Remove(storyline);

            // Assert          
            Assert.AreEqual(0, storyline.Characters.Count);
        }

        [TestMethod]
        public void StorylinesRemoveAt_StorylineContainsCharacter_CharacterIsRemovedFromStoryline()
        {
            // Arrange
            var storyline = new Storyline() { Name = "Storyline" };
            this.character.Storylines.Add(storyline);

            // Act
            this.character.Storylines.RemoveAt(0);

            // Assert          
            Assert.AreEqual(0, storyline.Characters.Count);
        }
    }
}
