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
    public class CharacterTest
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

        #region ToString
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
        #endregion

        #region Storylines property
        [TestMethod]
        public void StorylinesAdd_NewStoryline_StorylineContainsCharacter()
        {
            var storyline = new Storyline() { Name = "Storyline" };
            ManyToManyCollectionHelper.CollectionAdd_NewItem_RelatedCollectionContainsThis(this.character, storyline, this.character.Storylines, storyline.Characters);
        }

        [TestMethod]
        public void StorylinesInsert_NewStoryline_StorylineContainsCharacter()
        {
            var storyline = new Storyline() { Name = "Storyline" };
            ManyToManyCollectionHelper.CollectionInsert_NewItem_RelatedCollectionContainsThis(this.character, storyline, this.character.Storylines, storyline.Characters);
        }

        [TestMethod]
        public void StorylinesClear_StorylineContainsCharacter_CharacterIsRemovedFromStoryline()
        {
            var storyline = new Storyline() { Name = "Storyline" };
            ManyToManyCollectionHelper.CollectionClear_TestedObjectCollectionContainsRelatedObject_TestedObjectIsRemovedFromRelatedCollection(this.character, storyline, this.character.Storylines, storyline.Characters);
        }

        [TestMethod]
        public void StorylinesRemove_StorylineContainsCharacter_CharacterIsRemovedFromStoryline()
        {
            var storyline = new Storyline() { Name = "Storyline" };
            ManyToManyCollectionHelper.CollectionRemove_TestedObjectCollectionContainsRelatedObject_TestedObjectIsRemovedFromRelatedCollection(this.character, storyline, this.character.Storylines, storyline.Characters);
        }

        [TestMethod]
        public void StorylinesRemoveAt_StorylineContainsCharacter_CharacterIsRemovedFromStoryline()
        {
            var storyline = new Storyline() { Name = "Storyline" };
            ManyToManyCollectionHelper.CollectionRemoveAt_TestedObjectCollectionContainsRelatedObject_TestedObjectIsRemovedFromRelatedCollection(this.character, storyline, this.character.Storylines, storyline.Characters);
        }

        [TestMethod]
        public void StorylinesSet_StorylineContainsCharacter_CharacterIsRemovedFromOldStorylineAndAddedToNewStoryline()
        {
            var storyline = new Storyline() { Name = "Storyline" };
            var newStoryline = new Storyline() { Name = "NewStoryline" };

            ManyToManyCollectionHelper.CollectionSet_TestedObjectCollectionContainsRelatedObject_TestedObjectIsReplacedInRelatedCollection(this.character, storyline, newStoryline, this.character.Storylines, storyline.Characters, newStoryline.Characters);
        }

        #endregion

        #region Authors property
        [TestMethod]
        public void AuthorsAdd_NewAuthor_AuthorContainsCharacter()
        {
            var author = new Author() { Name = "Author" };
            ManyToManyCollectionHelper.CollectionAdd_NewItem_RelatedCollectionContainsThis(this.character, author, this.character.Authors, author.Characters);
        }

        [TestMethod]
        public void AuthorsInsert_NewAuthor_AuthorContainsCharacter()
        {
            var author = new Author() { Name = "Author" };
            ManyToManyCollectionHelper.CollectionInsert_NewItem_RelatedCollectionContainsThis(this.character, author, this.character.Authors, author.Characters);
        }

        [TestMethod]
        public void AuthorsClear_AuthorContainsCharacter_CharacterIsRemovedFromAuthor()
        {
            var author = new Author() { Name = "Author" };
            ManyToManyCollectionHelper.CollectionClear_TestedObjectCollectionContainsRelatedObject_TestedObjectIsRemovedFromRelatedCollection(this.character, author, this.character.Authors, author.Characters);
        }

        [TestMethod]
        public void AuthorsRemove_AuthorContainsCharacter_CharacterIsRemovedFromAuthor()
        {
            var author = new Author() { Name = "Author" };
            ManyToManyCollectionHelper.CollectionRemove_TestedObjectCollectionContainsRelatedObject_TestedObjectIsRemovedFromRelatedCollection(this.character, author, this.character.Authors, author.Characters);
        }

        [TestMethod]
        public void AuthorsRemoveAt_AuthorContainsCharacter_CharacterIsRemovedFromAuthor()
        {
            var author = new Author() { Name = "Author" };
            ManyToManyCollectionHelper.CollectionRemoveAt_TestedObjectCollectionContainsRelatedObject_TestedObjectIsRemovedFromRelatedCollection(this.character, author, this.character.Authors, author.Characters);
        }

        [TestMethod]
        public void AuthorsSet_AuthorContainsCharacter_CharacterIsRemovedFromOldAuthorAndAddedToNewAuthor()
        {
            var author = new Author() { Name = "Author" };
            var newAuthor = new Author() { Name = "NewAuthor" };

            ManyToManyCollectionHelper.CollectionSet_TestedObjectCollectionContainsRelatedObject_TestedObjectIsReplacedInRelatedCollection(this.character, author, newAuthor, this.character.Authors, author.Characters, newAuthor.Characters);
        }

        #endregion

        #region Tags property
        [TestMethod]
        public void TagsAdd_NewTag_TagContainsCharacter()
        {
            var tag = new Tag() { Name = "Tag" };
            ManyToManyCollectionHelper.CollectionAdd_NewItem_RelatedCollectionContainsThis(this.character, tag, this.character.Tags, tag.Characters);
        }

        [TestMethod]
        public void TagsInsert_NewTag_TagContainsCharacter()
        {
            var tag = new Tag() { Name = "Tag" };
            ManyToManyCollectionHelper.CollectionInsert_NewItem_RelatedCollectionContainsThis(this.character, tag, this.character.Tags, tag.Characters);
        }

        [TestMethod]
        public void TagsClear_TagContainsCharacter_CharacterIsRemovedFromTag()
        {
            var tag = new Tag() { Name = "Tag" };
            ManyToManyCollectionHelper.CollectionClear_TestedObjectCollectionContainsRelatedObject_TestedObjectIsRemovedFromRelatedCollection(this.character, tag, this.character.Tags, tag.Characters);
        }

        [TestMethod]
        public void TagsRemove_TagContainsCharacter_CharacterIsRemovedFromTag()
        {
            var tag = new Tag() { Name = "Tag" };
            ManyToManyCollectionHelper.CollectionRemove_TestedObjectCollectionContainsRelatedObject_TestedObjectIsRemovedFromRelatedCollection(this.character, tag, this.character.Tags, tag.Characters);
        }

        [TestMethod]
        public void TagsRemoveAt_TagContainsCharacter_CharacterIsRemovedFromTag()
        {
            var tag = new Tag() { Name = "Tag" };
            ManyToManyCollectionHelper.CollectionRemoveAt_TestedObjectCollectionContainsRelatedObject_TestedObjectIsRemovedFromRelatedCollection(this.character, tag, this.character.Tags, tag.Characters);
        }

        [TestMethod]
        public void TagsSet_TagContainsCharacter_CharacterIsRemovedFromOldTagAndAddedToNewTag()
        {
            var tag = new Tag() { Name = "Tag" };
            var newTag = new Tag() { Name = "NewTag" };

            ManyToManyCollectionHelper.CollectionSet_TestedObjectCollectionContainsRelatedObject_TestedObjectIsReplacedInRelatedCollection(this.character, tag, newTag, this.character.Tags, tag.Characters, newTag.Characters);
        }

        #endregion

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
        public void Relating_RelateCharacters_CharactersAreRelatedToEachOther()
        {
            // Arrange
            var newCharacter = new Character() { Name = "NewCharacter" };

            // Act
            this.character.RelateTo(newCharacter, relationshipName);

            // Assert          
            Assert.AreEqual(relationshipName, this.character.GetRelationshipsTo(newCharacter).Single());
            Assert.AreEqual(relationshipName, newCharacter.GetRelationshipsTo(this.character).Single());
        }

        [TestMethod]
        public void Relating_RelateCharacters_CharactersAreRelatedByRelationshipName()
        {
            // Arrange
            var newCharacter = new Character() { Name = "NewCharacter" };

            // Act
            this.character.RelateTo(newCharacter, relationshipName);

            // Assert          
            Assert.AreEqual(relationshipName, this.character.GetRelationshipsTo(newCharacter).Single());
            Assert.AreEqual(relationshipName, newCharacter.GetRelationshipsTo(this.character).Single());
            
        }

        // Relate character by relationship name with paired relationship
        [TestMethod]
        public void Relating_RelateCharactersPaired_CharactersAreRelatedToEachOtherWithTwoNames()
        {
            // Arrange
            var newCharacter = new Character() { Name = "NewCharacter" };

            // Act
            this.character.RelateTo(newCharacter, relationshipName, pairedRelationshipName);

            // Assert          
            Assert.AreEqual(2, this.character.GetRelationshipsTo(newCharacter).Count);
            Assert.IsTrue(this.character.GetRelationshipsTo(newCharacter).Contains(relationshipName));
            Assert.IsTrue(this.character.GetRelationshipsTo(newCharacter).Contains(pairedRelationshipName));

            Assert.AreEqual(2, newCharacter.GetRelationshipsTo(this.character).Count);
            Assert.IsTrue(newCharacter.GetRelationshipsTo(this.character).Contains(relationshipName));
            Assert.IsTrue(newCharacter.GetRelationshipsTo(this.character).Contains(pairedRelationshipName));
        }

        [TestMethod]
        public void Relating_RelateCharactersPaired_HasTwoRelationshipsWithTheCorrectNames()
        {
            // Arrange
            var newCharacter = new Character() { Name = "NewCharacter" };

            // Act
            this.character.RelateTo(newCharacter, relationshipName, pairedRelationshipName);

            // Assert          
            Assert.IsTrue(this.character.GetRelationshipsTo(newCharacter).Contains(relationshipName));
            Assert.IsTrue(this.character.GetRelationshipsTo(newCharacter).Contains(pairedRelationshipName));
            Assert.IsTrue(newCharacter.GetRelationshipsTo(this.character).Contains(relationshipName));
            Assert.IsTrue(newCharacter.GetRelationshipsTo(this.character).Contains(pairedRelationshipName));
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
            Assert.IsFalse(this.character.GetRelationshipsTo(newCharacter).Contains(pairedRelationshipName.ToUnsanitized()));
            Assert.IsTrue(this.character.GetRelationshipsTo(newCharacter).Contains(pairedRelationshipName.ToSanitized()));
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
