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
        const string toRelationDescription = "RelationTo";
        const string fromRelationDescription = "RelationFrom";
        const string secondToRelationDescription = "RelationTo2";
        const string secondFromRelationDescription = "RelationFrom2";
        const string characterParameterName = "character";
        const string relationDescriptionParameterName = "relationDescription";
        const string reverseRelationDescriptionParameterName = "reverseRelationDescription";

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
        #endregion

        #region RelateTo
        [TestMethod]
        public void RelateTo_CharacterIsNull_ThrowsArgumentNullException()
        {
            var exception = Assert.ThrowsException<ArgumentNullException>(() => this.character.RelateTo(null, toRelationDescription));
            Assert.AreEqual(characterParameterName, exception.ParamName);
        }

        [TestMethod]
        public void RelateTo_CharacterIsSelf_ThrowsArgumentException()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => this.character.RelateTo(this.character, toRelationDescription));
            Assert.AreEqual(characterParameterName, exception.ParamName);
        }

        [TestMethod]
        public void RelateTo_DescriptionIsEmpty_ThrowsArgumentException()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => this.character.RelateTo(new Character(), string.Empty));
            Assert.AreEqual(relationDescriptionParameterName, exception.ParamName);
        }

        [TestMethod]
        public void RelateTo_DescriptionIsNull_ThrowsArgumentNullException()
        {
            var exception = Assert.ThrowsException<ArgumentNullException>(() => this.character.RelateTo(new Character(), null));
            Assert.AreEqual(relationDescriptionParameterName, exception.ParamName);
        }

        [TestMethod]
        public void RelateTo_CharacterIsNew_CharacterIsRelatedToNewCharacter()
        {
            // Arrange
            var newCharacter = new Character() { Name = "CharacterName" };

            // Act
            this.character.RelateTo(newCharacter, toRelationDescription);

            // Assert          
            Assert.AreEqual(toRelationDescription, this.character.RelationTo(newCharacter));
        }
        
        [TestMethod]
        public void RelateToTwoWay_CharacterIsNull_ThrowsArgumentNullException()
        {
            var exception = Assert.ThrowsException<ArgumentNullException>(() => this.character.RelateTo(null, toRelationDescription, fromRelationDescription));
            Assert.AreEqual(characterParameterName, exception.ParamName);
        }

        [TestMethod]
        public void RelateToTwoWay_CharacterIsSelf_ThrowsArgumentException()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => this.character.RelateTo(this.character, toRelationDescription, fromRelationDescription));
            Assert.AreEqual(characterParameterName, exception.ParamName);
        }

        [TestMethod]
        public void RelateToTwoWay_DescriptionIsEmpty_ThrowsArgumentException()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => this.character.RelateTo(new Character(), string.Empty, fromRelationDescription));
            Assert.AreEqual(relationDescriptionParameterName, exception.ParamName);
        }

        [TestMethod]
        public void RelateToTwoWay_ReverseDescriptionIsEmpty_ThrowsArgumentException()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => this.character.RelateTo(new Character(), toRelationDescription, string.Empty));
            Assert.AreEqual(reverseRelationDescriptionParameterName, exception.ParamName);
        }

        [TestMethod]
        public void RelateToTwoWay_DescriptionIsNull_ThrowsArgumentNullException()
        {
            var exception = Assert.ThrowsException<ArgumentNullException>(() => this.character.RelateTo(new Character(), null, fromRelationDescription));
            Assert.AreEqual(relationDescriptionParameterName, exception.ParamName);
        }


        [TestMethod]
        public void RelateToTwoWay_ReverseDescriptionIsNull_ThrowsArgumentNullException()
        {
            var exception = Assert.ThrowsException<ArgumentNullException>(() => this.character.RelateTo(new Character(), toRelationDescription, null));
            Assert.AreEqual(reverseRelationDescriptionParameterName, exception.ParamName);
        }


        [TestMethod]
        public void RelateToTwoWay_CharacterIsNew_CharactersAreRelatedToEachOther()
        {
            // Arrange
            var newCharacter = new Character() { Name = "CharacterName" };

            // Act
            this.character.RelateTo(newCharacter, toRelationDescription, fromRelationDescription);

            // Assert          
            Assert.AreEqual(toRelationDescription, this.character.RelationTo(newCharacter));
            Assert.AreEqual(fromRelationDescription, newCharacter.RelationTo(this.character));
        }
        #endregion

        #region UnrelateTo
        [TestMethod]
        public void UnrelateTo_CharacterIsNull_ThrowsArgumentNullException()
        {
            var exception = Assert.ThrowsException<ArgumentNullException>(() => this.character.UnrelateTo(null));
            Assert.AreEqual(characterParameterName, exception.ParamName);
        }

        [TestMethod]
        public void UnrelateTo_CharacterIsSelf_ThrowsArgumentException()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => this.character.UnrelateTo(this.character));
            Assert.AreEqual(characterParameterName, exception.ParamName);
        }

        [TestMethod]
        public void UnrelateTo_CharacterIsUnrelated_ThrowsArgumentException()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => this.character.UnrelateTo(new Character()));
            Assert.AreEqual(characterParameterName, exception.ParamName);
        }
        #endregion

        [TestMethod]
        public void UnrelateTo_HasMultipleRelationsToRelatedCharacter_HasNoRelationsToRelatedCharacter()
        {
            // Arrange
            var relatedCharacter = new Character() { Name = "Character" };
            this.character.RelateTo(relatedCharacter, toRelationDescription);
            this.character.RelateTo(relatedCharacter, secondToRelationDescription);

            // Act
            this.character.UnrelateTo(relatedCharacter);

            // Assert          
            Assert.IsNull(this.character.RelationTo(relatedCharacter));
        }

        [TestMethod]
        public void UnrelateTo_HasMultipleTwoWayRelationsToRelatedCharacter_HasNoRelationsToRelatedCharacterButReverseRelationsRemain()
        {
            // Arrange
            var relatedCharacter = new Character() { Name = "Character" };
            this.character.RelateTo(relatedCharacter, toRelationDescription, fromRelationDescription);
            this.character.RelateTo(relatedCharacter, secondToRelationDescription, secondFromRelationDescription);

            // Act
            this.character.UnrelateTo(relatedCharacter);

            // Assert          
            Assert.IsNull(this.character.RelationTo(relatedCharacter));
            Assert.AreEqual(fromRelationDescription, relatedCharacter.RelationTo(this.character));
        }

        #region RelationTo
        [TestMethod]
        public void RelationTo_CharacterIsNull_ThrowsArgumentNullException()
        {
            var exception = Assert.ThrowsException<ArgumentNullException>(() => this.character.RelationTo(null));
            Assert.AreEqual(characterParameterName, exception.ParamName);
        }

        [TestMethod]
        public void RelationTo_CharacterIsSelf_ThrowsArgumentException()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => this.character.RelationTo(this.character));
            Assert.AreEqual(characterParameterName, exception.ParamName);
        }

        [TestMethod]
        public void RelationTo_CharacterIsUnrelated_ReturnsNull()
        {
            // Arrange
            // Act
            var relationDescription = this.character.RelationTo(new Character());

            // Assert          
            Assert.IsNull(relationDescription);
        }

        [TestMethod]
        public void RelationTo_CharacterIsRelated_ReturnsRelationDescription()
        {
            // Arrange
            var newCharacter = new Character() { Name = "NewCharacter" };
            this.character.RelateTo(newCharacter, toRelationDescription);

            // Act
            var relationDescription = this.character.RelationTo(newCharacter);

            // Assert          
            Assert.AreEqual(toRelationDescription, relationDescription);
        }

        [TestMethod]
        public void RelationTo_CharacterIsReverseRelated_ReturnsNull()
        {
            // Arrange
            var newCharacter = new Character() { Name = "NewCharacter" };
            this.character.RelateTo(newCharacter, toRelationDescription);

            // Act
            var relationDescription = newCharacter.RelationTo(this.character);

            // Assert          
            Assert.IsNull(relationDescription);
        }

        [TestMethod]
        public void RelationTo_CharacterIsTwoWayRelated_ReturnsFirstRelationDescription()
        {
            // Arrange
            var newCharacter = new Character() { Name = "NewCharacter" };
            this.character.RelateTo(newCharacter, toRelationDescription, fromRelationDescription);

            // Act
            var relationDescription = this.character.RelationTo(newCharacter);
            
            // Assert          
            Assert.AreEqual(toRelationDescription, relationDescription);            
        }

        [TestMethod]
        public void RelationTo_CharacterIsReverseTwoWayRelated_ReturnsSecondRelationDescription()
        {
            // Arrange
            var newCharacter = new Character() { Name = "NewCharacter" };
            this.character.RelateTo(newCharacter, toRelationDescription, fromRelationDescription);

            // Act
            var relationDescription = newCharacter.RelationTo(this.character);

            // Assert          
            Assert.AreEqual(fromRelationDescription, relationDescription);

        }
        #endregion
    }
}
