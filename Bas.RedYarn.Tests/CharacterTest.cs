using Bas.RedYarn.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Bas.RedYarn.Extensions;

namespace Bas.RedYarn
{
    [TestClass]
    public partial class CharacterTest
    {
        private Character character;
        const string relationshipName = "RelationshipName";
        const string pairedRelationshipName = "PairedRelationshipName";
        const string newRelationshipName = "NewRelationshipName";
        const string newPairedRelationshipName = "NewPairedRelationshipName";
        const string characterParameterName = "character";
        const string relationshipNameParameterName = "relationshipName";
        const string pairedRelationshipNameParameterName = "pairedRelationshipName";
        const string whiteSpace = "  \t  \n ";

        [TestInitialize]
        public void Initialize()
        {
            character = new Character();
        }

        #region RelateTo

        [TestMethod]
        public void RelateTo_CharacterIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            // Act
            // Assert          
            var exception = Assert.ThrowsException<ArgumentNullException>(() => this.character.RelateTo(null, relationshipName));
            Assert.AreEqual(characterParameterName, exception.ParamName);
        }

        [TestMethod]
        public void RelateTo_RelationshipNameIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            // Act          
            // Assert          
            var exception = Assert.ThrowsException<ArgumentNullException>(() => this.character.RelateTo(new Character(), null));
            Assert.AreEqual(relationshipNameParameterName, exception.ParamName);
        }
                
        [TestMethod]
        public void RelateTo_RelationshipNameIsWhiteSpace_ThrowsArgumentException()
        {
            
            // Arrange
            // Act          
            // Assert          
            var exception = Assert.ThrowsException<ArgumentException>(() => this.character.RelateTo(new Character(), whiteSpace));
            Assert.AreEqual(relationshipNameParameterName, exception.ParamName);            
        }

        [TestMethod]
        public void RelateTo_CharacterIsSelf_ThrowsArgumentException()
        {
            // Arrange
            // Act          
            // Assert          
            var exception = Assert.ThrowsException<ArgumentException>(() => this.character.RelateTo(this.character, relationshipName));
            Assert.AreEqual(characterParameterName, exception.ParamName);
        }

        [TestMethod]
        public void RelateTo_CharacterIsAlreadyRelatedToThatCharacterViaThatName_NothingHappens()
        {
            // Arrange
            var newCharacter = new Character();
            this.character.RelateTo(newCharacter, relationshipName);

            // Act          
            this.character.RelateTo(newCharacter, relationshipName);

            // Assert          
            Assert.AreEqual(1, this.character.GetRelationshipsTo(newCharacter).Count);
        }

        //[TestMethod]
        //public void RelateTo_IsDirectionalNonPairedRelationship_()
        //{
        //    // Arrange
        //    var newCharacter = new Character();
            
        //    // Act
        //    this.character.RelateTo(newCharacter, relationshipName, true)
        //    // Assert
        //}


        #endregion

        #region RelateToPaired
        [TestMethod]
        public void RelateToPaired_CharacterIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            // Act
            // Assert          
            var exception = Assert.ThrowsException<ArgumentNullException>(() => this.character.RelateTo(null, relationshipName, pairedRelationshipName));
            Assert.AreEqual(characterParameterName, exception.ParamName);
        }

        [TestMethod]
        public void RelateToPaired_RelationshipNameIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            // Act          
            // Assert          
            var exception = Assert.ThrowsException<ArgumentNullException>(() => this.character.RelateTo(new Character(), null, pairedRelationshipName));
            Assert.AreEqual(relationshipNameParameterName, exception.ParamName);
        }
                        
        [TestMethod]
        public void RelateToPaired_RelationshipNameIsWhiteSpace_ThrowsArgumentException()
        {

            // Arrange
            // Act          
            // Assert          
            var exception = Assert.ThrowsException<ArgumentException>(() => this.character.RelateTo(new Character(), "  \t  ", pairedRelationshipName));
            Assert.AreEqual(relationshipNameParameterName, exception.ParamName);
        }

        [TestMethod]
        public void RelateToPaired_PairedRelationshipNameIsWhiteSpace_ThrowsArgumentException()
        {

            // Arrange
            // Act          
            // Assert          
            var exception = Assert.ThrowsException<ArgumentException>(() => this.character.RelateTo(new Character(), relationshipName, "  \t  "));
            Assert.AreEqual(pairedRelationshipNameParameterName, exception.ParamName);
        }
                             
        [TestMethod]
        public void RelateToPaired_CharacterIsSelf_ThrowsArgumentException()
        {
            // Arrange
            // Act          
            // Assert          
            var exception = Assert.ThrowsException<ArgumentException>(() => this.character.RelateTo(this.character, relationshipName, pairedRelationshipName));
            Assert.AreEqual(characterParameterName, exception.ParamName);
        }

        [TestMethod]
        public void RelateToPaired_CharacterIsAlreadyRelatedToThatCharacterViaThatName_NothingHappens()
        {
            // Arrange
            var newCharacter = new Character();
            this.character.RelateTo(newCharacter, relationshipName, pairedRelationshipName);

            // Act          
            this.character.RelateTo(newCharacter, relationshipName, newPairedRelationshipName);

            // Assert          
            Assert.AreEqual(2, this.character.GetRelationshipsTo(newCharacter).Count);
        }

        [TestMethod]
        public void RelateToPaired_CharacterIsAlreadyRelatedToThatCharacterViaThatPairedName_NothingHappens()
        {
            // Arrange
            var newCharacter = new Character();
            this.character.RelateTo(newCharacter, relationshipName, pairedRelationshipName);

            // Act          
            this.character.RelateTo(newCharacter, newRelationshipName, relationshipName);

            // Assert          
            Assert.AreEqual(2, this.character.GetRelationshipsTo(newCharacter).Count);
        }

        [TestMethod]
        public void RelateToPaired_NamesAreTheSame_ThrowsNotSupportedException()
        {
            // Arrange
            // Act          
            // Assert          
            var exception = Assert.ThrowsException<NotSupportedException>(() => this.character.RelateTo(new Character(), relationshipName, relationshipName));            
        }
        #endregion

        #region UnrelateTo
        [TestMethod]
        public void UnRelateTo_CharacterIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            // Act          
            // Assert          
            var exception = Assert.ThrowsException<ArgumentNullException>(() => this.character.UnrelateTo(null));
            Assert.AreEqual(characterParameterName, exception.ParamName);
        }

        [TestMethod]
        public void UnrelateTo_CharacterIsSelf_ThrowsArgumentException()
        {
            // Arrange
            // Act          
            // Assert          
            var exception = Assert.ThrowsException<ArgumentException>(() => this.character.UnrelateTo(this.character));
            Assert.AreEqual(characterParameterName, exception.ParamName);
        }

        [TestMethod]
        public void UnrelateTo_CharacterIsUnrelated_NothingHappens()
        {
            // Arrange
            var newCharacter = new Character();
            // Act          
            this.character.UnrelateTo(newCharacter);

            // Assert          
            Assert.AreEqual(0, this.character.GetRelationshipsTo(newCharacter).Count);
        }
        
        [TestMethod]
        public void UnrelateTo_RelationshipNameIsWhiteSpace_NothingHappens()
        {
            // Arrange
            var newCharacter = new Character();
            this.character.RelateTo(newCharacter, relationshipName);

            // Act          
            this.character.UnrelateTo(newCharacter, whiteSpace);

            // Assert          
            Assert.AreEqual(1, this.character.GetRelationshipsTo(newCharacter).Count);
        }

        #endregion

        #region GetRelationshipsTo
        [TestMethod]
        public void GetRelationshipsTo_CharacterIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            // Act          
            // Assert          
            var exception = Assert.ThrowsException<ArgumentNullException>(() => this.character.GetRelationshipsTo(null));
            Assert.AreEqual(characterParameterName, exception.ParamName);
        }

        [TestMethod]
        public void GetRelationshipsTo_CharacterIsSelf_ThrowsArgumentException()
        {
            // Arrange
            // Act          
            // Assert          
            var exception = Assert.ThrowsException<ArgumentException>(() => this.character.GetRelationshipsTo(this.character));
            Assert.AreEqual(characterParameterName, exception.ParamName);
        }

        [TestMethod]
        public void GetRelationshipsTo_CharacterIsUnrelated_ReturnsEmptyCollection()
        {
            // Arrange
            // Act
            var relationships = this.character.GetRelationshipsTo(new Character());

            // Assert          
            Assert.AreEqual(0, relationships.Count);
        }
        #endregion

        #region Relating
        // Test the unit of relating characters, i.e. wether RelatingTo a character actually makes them RelatedTo characters.

        [TestMethod]
        public void Relating_RelateCharactersNonDirectional_CharactersAreRelatedToEachOther()
        {
            // Arrange
            var newCharacter = new Character() { Name = "NewCharacter" };

            // Act
            this.character.RelateTo(newCharacter, relationshipName);

            // Assert          
            var relationshipInfo = this.character.GetRelationshipsTo(newCharacter).Single();
            var otherCharacterRelationshipInfo = newCharacter.GetRelationshipsTo(this.character).Single();

            Assert.AreEqual(relationshipName, relationshipInfo.Name);
            Assert.AreEqual(relationshipName, otherCharacterRelationshipInfo.Name);
            Assert.AreEqual(RelationshipType.NonDirectional, relationshipInfo.Type);
            Assert.AreEqual(RelationshipType.NonDirectional, otherCharacterRelationshipInfo.Type);
        }
        
        // Relate character with paired relationship
        [TestMethod]
        public void Relating_RelateCharactersPaired_CharactersAreRelatedToEachOtherWithOneNameAndCorrectTypeEach()
        {
            // Arrange
            var newCharacter = new Character() { Name = "NewCharacter" };

            // Act
            this.character.RelateTo(newCharacter, relationshipName, pairedRelationshipName);

            // Assert          
            Assert.AreEqual(relationshipName, this.character.GetRelationshipsTo(newCharacter).Single().Name);
            Assert.AreEqual(RelationshipType.Forward, this.character.GetRelationshipsTo(newCharacter).Single().Type);

            Assert.AreEqual(pairedRelationshipName, newCharacter.GetRelationshipsTo(this.character).Single().Name);
            Assert.AreEqual(RelationshipType.Forward, newCharacter.GetRelationshipsTo(this.character).Single().Type);
        }
                

        [TestMethod]
        public void Relating_RelationscripNameIsUnsanitized_RelationshipNameIsSanitized()
        {
            // Arrange
            var newCharacter = new Character();
            // Act
            this.character.RelateTo(newCharacter, relationshipName.ToUnsanitized());

            // Assert          
            Assert.AreEqual(relationshipName.ToSanitized(), this.character.GetRelationshipsTo(newCharacter).Single());
        }

        [TestMethod]
        public void Relating_PairedRelationscripNameIsUnsanitized_PairedRelationshipNameIsSanitized()
        {
            // Arrange
            var newCharacter = new Character();
            // Act
            this.character.RelateTo(newCharacter, relationshipName, pairedRelationshipName.ToUnsanitized());

            // Assert          
            Assert.IsFalse(this.character.GetRelationshipsTo(newCharacter).Select(r => r.Name).Contains(pairedRelationshipName.ToUnsanitized()));
            Assert.IsTrue(this.character.GetRelationshipsTo(newCharacter).Select(r => r.Name).Contains(pairedRelationshipName.ToSanitized()));
        }
        #endregion

        #region Unrelating
        // Test the unit of unrelating characters, i.e. wether UnrelatingTo a character actually makes them no longer RelatedTo characters.

        [TestMethod]
        public void Unrelating_UnrelateAll_CharacterHasNoRelationshipsToNewCharacter()
        {
            // Arrange
            var newCharacter = new Character();
            var thirdCharacter = new Character();

            this.character.RelateTo(newCharacter, relationshipName);
            this.character.RelateTo(thirdCharacter, relationshipName);
            
            // Act
            this.character.UnrelateTo(newCharacter);

            // Assert          
            Assert.AreEqual(0, this.character.GetRelationshipsTo(newCharacter).Count);
            Assert.AreEqual(0, newCharacter.GetRelationshipsTo(this.character).Count);
            Assert.AreEqual(relationshipName, this.character.GetRelationshipsTo(thirdCharacter).Single());
            Assert.AreEqual(relationshipName, thirdCharacter.GetRelationshipsTo(this.character).Single());
        }

        [TestMethod]
        public void Unrelating_UnrelateAll_CharacterHasZeroRelationshipsWithCharacter()
        {
            // Arrange
            var newCharacter = new Character();
            var thirdCharacter = new Character();

            this.character.RelateTo(newCharacter, relationshipName);
            this.character.RelateTo(thirdCharacter, relationshipName);

            // Act
            this.character.UnrelateTo(newCharacter);

            // Assert          
            Assert.AreEqual(0, this.character.GetRelationshipsTo(newCharacter).Count);
            Assert.AreEqual(1, this.character.GetRelationshipsTo(thirdCharacter).Count);
        }

        [TestMethod]
        public void Unrelating_UnrelateByName_CharacterHasNoRelationshipByThatName()
        {
            // Arrange
            const string secondRelationshipName = "SecondRelationshipName";

            var newCharacter = new Character();
            this.character.RelateTo(newCharacter, relationshipName);
            this.character.RelateTo(newCharacter, secondRelationshipName);

            // Act
            this.character.UnrelateTo(newCharacter, relationshipName);

            // Assert          
            Assert.AreEqual(secondRelationshipName, this.character.GetRelationshipsTo(newCharacter).Single());
            Assert.AreEqual(secondRelationshipName, newCharacter.GetRelationshipsTo(this.character).Single());
        }

        [TestMethod]
        public void Unrelating_UnrelateByName_HasOneLessRelationship()
        {
            // Arrange
            const string secondRelationshipName = "SecondRelationshipName";

            var newCharacter = new Character();
            this.character.RelateTo(newCharacter, relationshipName);
            this.character.RelateTo(newCharacter, secondRelationshipName);

            // Act
            this.character.UnrelateTo(newCharacter, relationshipName);

            // Assert          
            Assert.AreEqual(secondRelationshipName, this.character.GetRelationshipsTo(newCharacter).Single());
        }

        [TestMethod]
        public void Unrelating_UnrelatePairedAndDeletePairedRelationship_BothRelationshipsAreDeleted()
        {
            // Arrange
            var newCharacter = new Character();
            this.character.RelateTo(newCharacter, relationshipName, pairedRelationshipName);

            // Act
            this.character.UnrelateTo(newCharacter, relationshipName, true);

            // Assert          
            Assert.AreEqual(0, this.character.GetRelationshipsTo(newCharacter).Count);
            Assert.AreEqual(0, newCharacter.GetRelationshipsTo(this.character).Count);
        }

        [TestMethod]
        public void Unrelating_UnrelatePairedButDontDeletePairedRelationship_OneRelationshipIsDeleted()
        {
            // Arrange
            var newCharacter = new Character();
            this.character.RelateTo(newCharacter, relationshipName, pairedRelationshipName);

            // Act
            this.character.UnrelateTo(newCharacter, relationshipName, false);

            // Assert          
            Assert.AreEqual(pairedRelationshipName, this.character.GetRelationshipsTo(newCharacter).Single());
            Assert.AreEqual(pairedRelationshipName, newCharacter.GetRelationshipsTo(this.character).Single());
        }
        #endregion
        
        #region IsRelatedTo
        [TestMethod]
        public void IsRelatedTo_CharacterIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            // Act          
            // Assert          
            var exception = Assert.ThrowsException<ArgumentNullException>(() => this.character.IsRelatedTo(null));
            Assert.AreEqual(characterParameterName, exception.ParamName);
        }

        [TestMethod]
        public void IsRelatedTo_CharacterIsSelf_ThrowsArgumentException()
        {
            // Arrange
            // Act          
            // Assert          
            var exception = Assert.ThrowsException<ArgumentException>(() => this.character.IsRelatedTo(this.character));
            Assert.AreEqual(characterParameterName, exception.ParamName);
        }

        [TestMethod]
        public void IsRelatedTo_CharacterIsRelatedToThatCharacterViaThatName_ReturnsTrue()
        {
            // Arrange
            var newCharacter = new Character();
            this.character.RelateTo(newCharacter, relationshipName);

            // Act          
            var result = this.character.IsRelatedTo(newCharacter, relationshipName);

            // Assert          
            Assert.IsTrue(result);            
        }

        [TestMethod]
        public void IsRelatedTo_CharacterIsRelatedToThatCharacterViaThatPairedName_ReturnsTrue()
        {
            // Arrange
            var newCharacter = new Character();
            this.character.RelateTo(newCharacter, relationshipName, pairedRelationshipName);

            // Act          
            var result = this.character.IsRelatedTo(newCharacter, pairedRelationshipName);

            // Assert          
            Assert.IsTrue(result);            
        }

        [TestMethod]
        public void IsRelatedTo_CharacterIsUnrelated_ReturnsFalse()
        {
            // Arrange
            var newCharacter = new Character();
            
            // Act          
            var result = this.character.IsRelatedTo(newCharacter);

            // Assert          
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsRelatedTo_RelationshipNameIsWhiteSpace_ThrowsArgumentException()
        {
            // Arrange
            var newCharacter = new Character();
            this.character.RelateTo(newCharacter, relationshipName);

            // Act          
            // Assert          
            var exception = Assert.ThrowsException<ArgumentException>(() => this.character.IsRelatedTo(newCharacter, whiteSpace));
            Assert.AreEqual(relationshipNameParameterName, exception.ParamName);
        }

        [TestMethod]
        public void IsRelatedTo_CharactersAreRelated_ReturnsTrue()
        {
            // Arrange
            var newCharacter = new Character() { Name = "NewCharacter" };
            this.character.RelateTo(newCharacter, relationshipName);

            // Act
            var result = this.character.IsRelatedTo(newCharacter);

            // Assert          
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsRelatedTo_CharactersAreRelatedByRelationshipName_ReturnsTrue()
        {
            // Arrange
            var newCharacter = new Character() { Name = "NewCharacter" };
            this.character.RelateTo(newCharacter, relationshipName);

            // Act
            var result = this.character.IsRelatedTo(newCharacter, relationshipName);

            // Assert          
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsRelatedTo_CharactersAreRelatedByDifferentName_ReturnsFalse()
        {
            // Arrange
            var newCharacter = new Character() { Name = "NewCharacter" };
            this.character.RelateTo(newCharacter, relationshipName + "2");

            // Act
            var result = this.character.IsRelatedTo(newCharacter, relationshipName);

            // Assert          
            Assert.IsFalse(result);
        }
        #endregion
    }
}
