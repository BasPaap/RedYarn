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
        const string relationshipDescription = "RelationshipDescription";
        const string pairedRelationshipDescription = "PairedRelationshipDescription";
        const string newRelationshipDescription = "NewRelationshipDescription";
        const string newPairedRelationshipDescription = "NewPairedRelationshipDescription";
        const string characterParameterName = "character";
        const string relationshipDescriptionParameterName = "relationshipDescription";
        const string pairedRelationshipDescriptionParameterName = "pairedRelationshipDescription";
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
            var exception = Assert.ThrowsException<ArgumentNullException>(() => this.character.RelateTo(null, relationshipDescription));
            Assert.AreEqual(characterParameterName, exception.ParamName);
        }

        [TestMethod]
        public void RelateTo_RelationshipDescriptionIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            // Act          
            // Assert          
            var exception = Assert.ThrowsException<ArgumentNullException>(() => this.character.RelateTo(new Character(), null));
            Assert.AreEqual(relationshipDescriptionParameterName, exception.ParamName);
        }

        [TestMethod]
        public void RelateTo_RelationshipDescriptionIsEmpty_ThrowsArgumentException()
        {
            // Arrange
            // Act          
            // Assert          
            var exception = Assert.ThrowsException<ArgumentException>(() => this.character.RelateTo(new Character(), string.Empty));
            Assert.AreEqual(relationshipDescription, exception.ParamName);
        }

        [TestMethod]
        public void RelateTo_RelationshipDescriptionIsWhiteSpace_ThrowsArgumentException()
        {
            
            // Arrange
            // Act          
            // Assert          
            var exception = Assert.ThrowsException<ArgumentException>(() => this.character.RelateTo(new Character(), whiteSpace));
            Assert.AreEqual(relationshipDescription, exception.ParamName);            
        }

        [TestMethod]
        public void RelateTo_CharacterIsSelf_ThrowsArgumentException()
        {
            // Arrange
            // Act          
            // Assert          
            var exception = Assert.ThrowsException<ArgumentException>(() => this.character.RelateTo(this.character, relationshipDescription));
            Assert.AreEqual(characterParameterName, exception.ParamName);
        }

        [TestMethod]
        public void RelateTo_CharacterIsAlreadyRelatedToThatCharacterViaThatDescription_ThrowsInvalidOperationException()
        {
            // Arrange
            var newCharacter = new Character();
            this.character.RelateTo(newCharacter, relationshipDescription);

            // Act          
            // Assert          
            var exception = Assert.ThrowsException<InvalidOperationException>(() => this.character.RelateTo(newCharacter, relationshipDescription));
        }

        #endregion

        #region RelateToPaired
        [TestMethod]
        public void RelateToPaired_CharacterIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            // Act
            // Assert          
            var exception = Assert.ThrowsException<ArgumentNullException>(() => this.character.RelateTo(null, relationshipDescription, pairedRelationshipDescription));
            Assert.AreEqual(characterParameterName, exception.ParamName);
        }

        [TestMethod]
        public void RelateToPaired_RelationshipDescriptionIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            // Act          
            // Assert          
            var exception = Assert.ThrowsException<ArgumentNullException>(() => this.character.RelateTo(new Character(), null, pairedRelationshipDescription));
            Assert.AreEqual(relationshipDescriptionParameterName, exception.ParamName);
        }

        [TestMethod]
        public void RelateToPaired_PairedRelationshipDescriptionIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            // Act          
            // Assert          
            var exception = Assert.ThrowsException<ArgumentNullException>(() => this.character.RelateTo(new Character(), relationshipDescription,  null));
            Assert.AreEqual(pairedRelationshipDescriptionParameterName, exception.ParamName);
        }
        
        [TestMethod]
        public void RelateToPaired_RelationshipDescriptionIsEmpty_ThrowsArgumentException()
        {
            // Arrange
            // Act          
            // Assert          
            var exception = Assert.ThrowsException<ArgumentException>(() => this.character.RelateTo(new Character(), string.Empty, pairedRelationshipDescription));
            Assert.AreEqual(relationshipDescription, exception.ParamName);
        }

        [TestMethod]
        public void RelateToPaired_PairedRelationshipDescriptionIsEmpty_ThrowsArgumentException()
        {
            // Arrange
            // Act          
            // Assert          
            var exception = Assert.ThrowsException<ArgumentException>(() => this.character.RelateTo(new Character(), relationshipDescription, string.Empty));
            Assert.AreEqual(pairedRelationshipDescription, exception.ParamName);
        }

        [TestMethod]
        public void RelateToPaired_RelationshipDescriptionIsWhiteSpace_ThrowsArgumentException()
        {

            // Arrange
            // Act          
            // Assert          
            var exception = Assert.ThrowsException<ArgumentException>(() => this.character.RelateTo(new Character(), "  \t  ", pairedRelationshipDescription));
            Assert.AreEqual(relationshipDescription, exception.ParamName);
        }

        [TestMethod]
        public void RelateToPaired_PairedRelationshipDescriptionIsWhiteSpace_ThrowsArgumentException()
        {

            // Arrange
            // Act          
            // Assert          
            var exception = Assert.ThrowsException<ArgumentException>(() => this.character.RelateTo(new Character(), relationshipDescription, "  \t  "));
            Assert.AreEqual(pairedRelationshipDescription, exception.ParamName);
        }
                             
        [TestMethod]
        public void RelateToPaired_CharacterIsSelf_ThrowsArgumentException()
        {
            // Arrange
            // Act          
            // Assert          
            var exception = Assert.ThrowsException<ArgumentException>(() => this.character.RelateTo(this.character, relationshipDescription, pairedRelationshipDescription));
            Assert.AreEqual(characterParameterName, exception.ParamName);
        }

        [TestMethod]
        public void RelateToPaired_CharacterIsAlreadyRelatedToThatCharacterViaThatDescription_ThrowsInvalidOperationException()
        {
            // Arrange
            var newCharacter = new Character();
            this.character.RelateTo(newCharacter, relationshipDescription, pairedRelationshipDescription);

            // Act          
            // Assert          
            var exception = Assert.ThrowsException<InvalidOperationException>(() => this.character.RelateTo(newCharacter, relationshipDescription, newPairedRelationshipDescription));
        }

        [TestMethod]
        public void RelateToPaired_CharacterIsAlreadyRelatedToThatCharacterViaThatPairedDescription_ThrowsInvalidOperationException()
        {
            // Arrange
            var newCharacter = new Character();
            this.character.RelateTo(newCharacter, relationshipDescription, pairedRelationshipDescription);

            // Act          
            // Assert          
            var exception = Assert.ThrowsException<InvalidOperationException>(() => this.character.RelateTo(newCharacter, newRelationshipDescription, relationshipDescription));
        }

        [TestMethod]
        public void RelateToPaired_DescriptionsAreTheSame_ThrowsNotSupportedException()
        {
            // Arrange
            // Act          
            // Assert          
            var exception = Assert.ThrowsException<NotSupportedException>(() => this.character.RelateTo(new Character(), relationshipDescription, relationshipDescription));            
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
        public void UnrelateTo_CharacterIsUnrelated_ThrowsArgumentException()
        {
            // Arrange
            // Act          
            // Assert          
            var exception = Assert.ThrowsException<ArgumentException>(() => this.character.UnrelateTo(new Character()));
            Assert.AreEqual(characterParameterName, exception.ParamName);
        }

        [TestMethod]
        public void UnrelateTo_RelationshipDescriptionIsEmpty_ThrowsArgumentException()
        {
            // Arrange
            var newCharacter = new Character();
            this.character.RelateTo(newCharacter, relationshipDescription);
            // Act          
            // Assert          
            var exception = Assert.ThrowsException<ArgumentException>(() => this.character.UnrelateTo(newCharacter, string.Empty));
            Assert.AreEqual(relationshipDescriptionParameterName, exception.ParamName);
        }

        [TestMethod]
        public void UnrelateTo_RelationshipDescriptionIsWhiteSpace_ThrowsArgumentException()
        {
            // Arrange
            var newCharacter = new Character();
            this.character.RelateTo(newCharacter, relationshipDescription);

            // Act          
            // Assert          
            var exception = Assert.ThrowsException<ArgumentException>(() => this.character.UnrelateTo(newCharacter, whiteSpace));
            Assert.AreEqual(relationshipDescriptionParameterName, exception.ParamName);
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
            this.character.RelateTo(newCharacter, relationshipDescription);

            // Assert          
            Assert.AreEqual(relationshipDescription, this.character.GetRelationshipsTo(newCharacter).Single());
            Assert.AreEqual(relationshipDescription, newCharacter.GetRelationshipsTo(this.character).Single());
        }

        // Relate character by description with paired relationship
        [TestMethod]
        public void Relating_RelateCharactersPaired_CharactersAreRelatedToEachOtherWithTwoDescriptions()
        {
            // Arrange
            var newCharacter = new Character() { Name = "NewCharacter" };

            // Act
            this.character.RelateTo(newCharacter, relationshipDescription, pairedRelationshipDescription);

            // Assert          
            Assert.AreEqual(2, this.character.GetRelationshipsTo(newCharacter).Count);
            Assert.IsTrue(this.character.GetRelationshipsTo(newCharacter).Contains(relationshipDescription));
            Assert.IsTrue(this.character.GetRelationshipsTo(newCharacter).Contains(pairedRelationshipDescription));

            Assert.AreEqual(2, newCharacter.GetRelationshipsTo(this.character).Count);
            Assert.IsTrue(newCharacter.GetRelationshipsTo(this.character).Contains(relationshipDescription));
            Assert.IsTrue(newCharacter.GetRelationshipsTo(this.character).Contains(pairedRelationshipDescription));
        }

        #endregion

        #region Unrelating
        // Test the unit of unrelating characters, i.e. wether UnrelatingTo a character actually makes them no longer RelatedTo characters.
        #endregion
    }
}
