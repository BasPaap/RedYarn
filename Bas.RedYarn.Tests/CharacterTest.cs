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
            Assert.AreEqual(toRelationDescription, this.character.RelationsTo(newCharacter).Single());
        }

        [TestMethod]
        public void RelateTo_CharacterIsNewAndHasMultipleRelations_CharacterHasMultipleRelationsToNewCharacter()
        {
            // Arrange
            var newCharacter = new Character() { Name = "CharacterName" };

            // Act
            this.character.RelateTo(newCharacter, toRelationDescription);
            this.character.RelateTo(newCharacter, secondToRelationDescription);

            // Assert          
            Assert.AreEqual(2, this.character.RelationsTo(newCharacter).Count);
            Assert.IsTrue(this.character.RelationsTo(newCharacter).Contains(toRelationDescription));
            Assert.IsTrue(this.character.RelationsTo(newCharacter).Contains(secondToRelationDescription));
        }

        [TestMethod]
        public void RelateTo_DescriptionIsUnsanitized_DescriptionIsSanitized()
        {
            // Arrange
            var newCharacter = new Character() { Name = "CharacterName" };

            // Act
            this.character.RelateTo(newCharacter, toRelationDescription.ToUnsanitized());

            // Assert          
            Assert.AreEqual(toRelationDescription.ToSanitized(), this.character.RelationsTo(newCharacter).Single());
        }

        [TestMethod]
        public void RelateToTwoWay_DescriptionIsUnsanitized_DescriptionIsSanitized()
        {
            // Arrange
            var newCharacter = new Character() { Name = "CharacterName" };

            // Act
            this.character.RelateTo(newCharacter, toRelationDescription.ToUnsanitized(), fromRelationDescription);

            // Assert          
            Assert.AreEqual(toRelationDescription.ToSanitized(), this.character.RelationsTo(newCharacter).Single());
        }

        [TestMethod]
        public void RelateToTwoWay_ReverseDescriptionIsUnsanitized_DescriptionIsSanitized()
        {
            // Arrange
            var newCharacter = new Character() { Name = "CharacterName" };

            // Act
            this.character.RelateTo(newCharacter, toRelationDescription, fromRelationDescription.ToUnsanitized());

            // Assert          
            Assert.AreEqual(fromRelationDescription.ToSanitized(), newCharacter.RelationsTo(this.character).Single());
        }

        [TestMethod]
        public void RelateTo_DescriptionAlreadyExists_ThrowsArgumentException()
        {
            // Arrange
            var newCharacter = new Character() { Name = "CharacterName" };
            this.character.RelateTo(newCharacter, toRelationDescription);

            // Act
            // Assert
            var exception = Assert.ThrowsException<ArgumentException>(() => this.character.RelateTo(newCharacter, toRelationDescription.ToUpper()));
            Assert.AreEqual(relationDescriptionParameterName, exception.ParamName);
        }

        [TestMethod]
        public void RelateToTwoWay_DescriptionAlreadyExists_ThrowsArgumentException()
        {
            // Arrange
            var newCharacter = new Character() { Name = "CharacterName" };
            this.character.RelateTo(newCharacter, toRelationDescription, fromRelationDescription);

            // Act
            // Assert
            var exception = Assert.ThrowsException<ArgumentException>(() => this.character.RelateTo(newCharacter, toRelationDescription.ToUpper(), "new"));
            Assert.AreEqual(relationDescriptionParameterName, exception.ParamName);
        }

        [TestMethod]
        public void RelateToTwoWay_ReverseDescriptionAlreadyExists_ThrowsArgumentException()
        {
            // Arrange
            var newCharacter = new Character() { Name = "CharacterName" };
            this.character.RelateTo(newCharacter, toRelationDescription, fromRelationDescription);

            // Act
            // Assert
            var exception = Assert.ThrowsException<ArgumentException>(() => this.character.RelateTo(newCharacter, "new", fromRelationDescription.ToUpper()));
            Assert.AreEqual(reverseRelationDescriptionParameterName, exception.ParamName);
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
            Assert.AreEqual(toRelationDescription, this.character.RelationsTo(newCharacter).Single());
            Assert.AreEqual(fromRelationDescription, newCharacter.RelationsTo(this.character).Single());
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
            Assert.AreEqual(0, this.character.RelationsTo(relatedCharacter).Count);
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
            Assert.AreEqual(0, this.character.RelationsTo(relatedCharacter).Count);
            Assert.AreEqual(2, relatedCharacter.RelationsTo(this.character).Count);
            Assert.IsTrue(relatedCharacter.RelationsTo(this.character).Contains(fromRelationDescription));
            Assert.IsTrue(relatedCharacter.RelationsTo(this.character).Contains(secondFromRelationDescription));
        }

        [TestMethod]
        public void UnrelateToSpecific_CharacterIsNull_ThrowsArgumentNullException()
        {
            var exception = Assert.ThrowsException<ArgumentNullException>(() => this.character.UnrelateTo(null, fromRelationDescription));
            Assert.AreEqual(characterParameterName, exception.ParamName);
        }

        [TestMethod]
        public void UnrelateToSpecific_CharacterIsSelf_ThrowsArgumentException()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => this.character.UnrelateTo(this.character, fromRelationDescription));
            Assert.AreEqual(characterParameterName, exception.ParamName);
        }

        [TestMethod]
        public void UnrelateToSpecific_CharacterIsUnrelated_ThrowsArgumentException()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => this.character.UnrelateTo(new Character(), fromRelationDescription));
            Assert.AreEqual(characterParameterName, exception.ParamName);
        }

        [TestMethod]
        public void UnrelateToSpecific_RelationDescriptionIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            var relatedCharacter = new Character() { Name = "RelatedCharacter" };
            this.character.RelateTo(relatedCharacter, fromRelationDescription);

            // Act
            // Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => this.character.UnrelateTo(relatedCharacter, null));
            Assert.AreEqual(relationDescriptionParameterName, exception.ParamName);
        }

        [TestMethod]
        public void UnrelateToSpecific_RelationDescriptionIsEmpty_ThrowsArgumentException()
        {
            // Arrange
            var relatedCharacter = new Character() { Name = "RelatedCharacter" };
            this.character.RelateTo(relatedCharacter, fromRelationDescription);

            // Act
            // Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => this.character.UnrelateTo(relatedCharacter, string.Empty));
            Assert.AreEqual(relationDescriptionParameterName, exception.ParamName);
        }

        [TestMethod]
        public void UnrelateToSpecific_RelationDescriptionIsUnknown_ThrowsArgumentException()
        {
            // Arrange
            var relatedCharacter = new Character() { Name = "RelatedCharacter" };
            this.character.RelateTo(relatedCharacter, fromRelationDescription);

            // Act
            // Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => this.character.UnrelateTo(relatedCharacter, "UnknownRelation"));
            Assert.AreEqual(relationDescriptionParameterName, exception.ParamName);
        }

        [TestMethod]
        public void UnrelateToSpecific_OneWayRelationDescriptionIsKnown_RelationIsRemoved()
        {
            // Arrange
            var firstRelatedCharacter = new Character() { Name = "FirstRelatedCharacter" };
            var secondRelatedCharacter = new Character() { Name = "SecondRelatedCharacter" };
            this.character.RelateTo(firstRelatedCharacter, toRelationDescription);
            this.character.RelateTo(secondRelatedCharacter, secondToRelationDescription);

            // Act
            this.character.UnrelateTo(firstRelatedCharacter, toRelationDescription);

            // Assert
            Assert.AreEqual(0, this.character.RelationsTo(firstRelatedCharacter).Count);
            Assert.AreEqual(1, this.character.RelationsTo(secondRelatedCharacter).Count);
            Assert.AreEqual(secondToRelationDescription, this.character.RelationsTo(secondRelatedCharacter).Single());
        }

        [TestMethod]
        public void UnrelateToSpecific_TwoWayToRelationDescriptionIsKnown_RelationIsRemoved()
        {
            // Arrange
            var firstRelatedCharacter = new Character() { Name = "FirstRelatedCharacter" };
            var secondRelatedCharacter = new Character() { Name = "SecondRelatedCharacter" };
            this.character.RelateTo(firstRelatedCharacter, toRelationDescription, fromRelationDescription);
            this.character.RelateTo(secondRelatedCharacter, secondToRelationDescription, secondFromRelationDescription);

            // Act
            this.character.UnrelateTo(firstRelatedCharacter, toRelationDescription);

            // Assert
            Assert.AreEqual(0, this.character.RelationsTo(firstRelatedCharacter).Count);
            Assert.AreEqual(0, firstRelatedCharacter.RelationsTo(this.character).Count);

            Assert.AreEqual(1, this.character.RelationsTo(secondRelatedCharacter).Count);
            Assert.AreEqual(secondToRelationDescription, this.character.RelationsTo(secondRelatedCharacter).Single());
            
            Assert.AreEqual(1, secondRelatedCharacter.RelationsTo(this.character).Count);
            Assert.AreEqual(secondFromRelationDescription, secondRelatedCharacter.RelationsTo(this.character).Single());
        }

        [TestMethod]
        public void UnrelateToSpecific_TwoWayFromRelationDescriptionIsKnown_RelationIsRemoved()
        {
            // Arrange
            var firstRelatedCharacter = new Character() { Name = "FirstRelatedCharacter" };
            var secondRelatedCharacter = new Character() { Name = "SecondRelatedCharacter" };
            this.character.RelateTo(firstRelatedCharacter, toRelationDescription, fromRelationDescription);
            this.character.RelateTo(secondRelatedCharacter, secondToRelationDescription, secondFromRelationDescription);

            // Act
            this.character.UnrelateTo(firstRelatedCharacter, fromRelationDescription);

            // Assert
            Assert.AreEqual(0, this.character.RelationsTo(firstRelatedCharacter).Count);
            Assert.AreEqual(0, firstRelatedCharacter.RelationsTo(this.character).Count);

            Assert.AreEqual(1, this.character.RelationsTo(secondRelatedCharacter).Count);
            Assert.AreEqual(secondToRelationDescription, this.character.RelationsTo(secondRelatedCharacter).Single());

            Assert.AreEqual(1, secondRelatedCharacter.RelationsTo(this.character).Count);
            Assert.AreEqual(secondFromRelationDescription, secondRelatedCharacter.RelationsTo(this.character).Single());
        }

        #endregion

        #region RelationsTo
        [TestMethod]
        public void RelationTo_CharacterIsNull_ThrowsArgumentNullException()
        {
            var exception = Assert.ThrowsException<ArgumentNullException>(() => this.character.RelationsTo(null));
            Assert.AreEqual(characterParameterName, exception.ParamName);
        }

        [TestMethod]
        public void RelationTo_CharacterIsSelf_ThrowsArgumentException()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => this.character.RelationsTo(this.character));
            Assert.AreEqual(characterParameterName, exception.ParamName);
        }

        [TestMethod]
        public void RelationTo_CharacterIsUnrelated_ReturnsNull()
        {
            // Arrange
            // Act
            var relations = this.character.RelationsTo(new Character());

            // Assert          
            Assert.AreEqual(0, relations.Count);
        }

        [TestMethod]
        public void RelationTo_CharacterIsRelated_ReturnsRelationDescription()
        {
            // Arrange
            var newCharacter = new Character() { Name = "NewCharacter" };
            this.character.RelateTo(newCharacter, toRelationDescription);

            // Act
            var relations = this.character.RelationsTo(newCharacter);

            // Assert          
            Assert.AreEqual(toRelationDescription, relations.Single());
        }

        [TestMethod]
        public void RelationTo_CharacterIsReverseRelated_ReturnsNull()
        {
            // Arrange
            var newCharacter = new Character() { Name = "NewCharacter" };
            this.character.RelateTo(newCharacter, toRelationDescription);

            // Act
            var relations = newCharacter.RelationsTo(this.character);

            // Assert          
            Assert.AreEqual(0, relations.Count);
        }

        [TestMethod]
        public void RelationTo_CharacterIsTwoWayRelated_ReturnsToRelationDescription()
        {
            // Arrange
            var newCharacter = new Character() { Name = "NewCharacter" };
            this.character.RelateTo(newCharacter, toRelationDescription, fromRelationDescription);

            // Act
            var relations = this.character.RelationsTo(newCharacter);
            
            // Assert          
            Assert.AreEqual(toRelationDescription, relations.Single());            
        }

        [TestMethod]
        public void RelationTo_CharacterIsReverseTwoWayRelated_ReturnsFromRelationDescription()
        {
            // Arrange
            var newCharacter = new Character() { Name = "NewCharacter" };
            this.character.RelateTo(newCharacter, toRelationDescription, fromRelationDescription);

            // Act
            var relations = newCharacter.RelationsTo(this.character);

            // Assert          
            Assert.AreEqual(fromRelationDescription, relations.Single());
        }
        #endregion
    }
}
