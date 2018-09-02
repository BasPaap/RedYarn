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
        const string toRelationshipDescription = "RelationshipTo";
        const string fromRelationshipDescription = "RelationshipFrom";
        const string secondToRelationshipDescription = "RelationshipTo2";
        const string secondFromRelationshipDescription = "RelationshipFrom2";
        const string characterParameterName = "character";
        const string relationshipDescriptionParameterName = "relationshipDescription";
        const string reverseRelationshipDescriptionParameterName = "reverseRelationshipDescription";

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
        public void RelateTo_NonDirectionalCharacterIsNull_ThrowsArgumentNullException()
        {
            var exception = Assert.ThrowsException<ArgumentNullException>(() => this.character.RelateTo(null, toRelationshipDescription));
            Assert.AreEqual(characterParameterName, exception.ParamName);
        }

        [TestMethod]
        public void RelateTo_NonDirectionalCharacterIsSelf_ThrowsArgumentException()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => this.character.RelateTo(this.character, toRelationshipDescription));
            Assert.AreEqual(characterParameterName, exception.ParamName);
        }

        [TestMethod]
        public void RelateTo_NonDirectionalDescriptionIsEmpty_ThrowsArgumentException()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => this.character.RelateTo(new Character(), string.Empty));
            Assert.AreEqual(relationshipDescriptionParameterName, exception.ParamName);
        }

        [TestMethod]
        public void RelateTo_NonDirectionalDescriptionIsNull_ThrowsArgumentNullException()
        {
            var exception = Assert.ThrowsException<ArgumentNullException>(() => this.character.RelateTo(new Character(), null));
            Assert.AreEqual(relationshipDescriptionParameterName, exception.ParamName);
        }

        [TestMethod]
        public void RelateTo_NonDirectionalCharacterIsNew_CharacterIsRelatedToNewCharacterAndNewCharacterIsRelatedToCharacter()
        {
            // Arrange
            var newCharacter = new Character() { Name = "CharacterName" };

            // Act
            this.character.RelateTo(newCharacter, toRelationshipDescription);

            // Assert          
            Assert.AreEqual(toRelationshipDescription, this.character.RelationshipsTo(newCharacter).Single());
            Assert.AreEqual(toRelationshipDescription, newCharacter.RelationshipsTo(this.character).Single());
        }

        [TestMethod]
        public void RelateTo_NonDirectionalCharacterIsNewAndHasMultipleRelations_CharacterHasMultipleRelationshipsToNewCharacter()
        {
            // Arrange
            var newCharacter = new Character() { Name = "CharacterName" };

            // Act
            this.character.RelateTo(newCharacter, toRelationshipDescription);
            this.character.RelateTo(newCharacter, secondToRelationshipDescription);

            // Assert          
            Assert.AreEqual(2, this.character.RelationshipsTo(newCharacter).Count);
            Assert.IsTrue(this.character.RelationshipsTo(newCharacter).Contains(toRelationshipDescription));
            Assert.IsTrue(this.character.RelationshipsTo(newCharacter).Contains(secondToRelationshipDescription));
        }

        [TestMethod]
        public void RelateTo_NonDirectionalDescriptionIsUnsanitized_DescriptionIsSanitized()
        {
            // Arrange
            var newCharacter = new Character() { Name = "CharacterName" };

            // Act
            this.character.RelateTo(newCharacter, toRelationshipDescription.ToUnsanitized());

            // Assert          `
            Assert.AreEqual(toRelationshipDescription.ToSanitized(), this.character.RelationshipsTo(newCharacter).Single());
        }

        [TestMethod]
        public void RelateTo_NonDirectionalDescriptionOnlyConsistsOfIllegalCharacters_ThrowsArgumentException()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => this.character.RelateTo(new Character(), "  \0\n "));
            Assert.AreEqual(relationshipDescriptionParameterName, exception.ParamName);
        }

        [TestMethod]
        public void RelateTo_NonDirectionalDescriptionAlreadyExists_ThrowsArgumentException()
        {
            // Arrange
            var newCharacter = new Character() { Name = "CharacterName" };
            this.character.RelateTo(newCharacter, toRelationshipDescription);

            // Act
            // Assert
            var exception = Assert.ThrowsException<ArgumentException>(() => this.character.RelateTo(newCharacter, toRelationshipDescription.ToUpper()));
            Assert.AreEqual(relationshipDescriptionParameterName, exception.ParamName);
        }
        
        [TestMethod]
        public void RelateTo_OneWayCharacterIsNull_ThrowsArgumentNullException()
        {
            var exception = Assert.ThrowsException<ArgumentNullException>(() => this.character.RelateTo(null, toRelationshipDescription, true));
            Assert.AreEqual(characterParameterName, exception.ParamName);
        }
     
        [TestMethod]
        public void RelateTo_OneWayCharacterIsSelf_ThrowsArgumentException()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => this.character.RelateTo(this.character, toRelationshipDescription, true));
            Assert.AreEqual(characterParameterName, exception.ParamName);
        }

        [TestMethod]
        public void RelateTo_OneWayDescriptionIsEmpty_ThrowsArgumentException()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => this.character.RelateTo(new Character(), string.Empty, true));
            Assert.AreEqual(relationshipDescriptionParameterName, exception.ParamName);
        }

        [TestMethod]
        public void RelateTo_OneWayDescriptionIsNull_ThrowsArgumentNullException()
        {
            var exception = Assert.ThrowsException<ArgumentNullException>(() => this.character.RelateTo(new Character(), null, true));
            Assert.AreEqual(relationshipDescriptionParameterName, exception.ParamName);
        }

        [TestMethod]
        public void RelateTo_OneWayCharacterIsNew_CharacterIsRelatedToNewCharacter()
        {
            // Arrange
            var newCharacter = new Character() { Name = "CharacterName" };

            // Act
            this.character.RelateTo(newCharacter, toRelationshipDescription, true);

            // Assert          
            Assert.AreEqual(toRelationshipDescription, this.character.RelationshipsTo(newCharacter).Single());
            Assert.AreEqual(0, newCharacter.RelationshipsTo(this.character).Count);
        }

        [TestMethod]
        public void RelateTo_OneWayCharacterIsNewAndHasMultipleRelations_CharacterHasMultipleRelationshipsToNewCharacter()
        {
            // Arrange
            var newCharacter = new Character() { Name = "CharacterName" };

            // Act
            this.character.RelateTo(newCharacter, toRelationshipDescription, true);
            this.character.RelateTo(newCharacter, secondToRelationshipDescription, true);

            // Assert          
            Assert.AreEqual(2, this.character.RelationshipsTo(newCharacter).Count);
            Assert.IsTrue(this.character.RelationshipsTo(newCharacter).Contains(toRelationshipDescription));
            Assert.IsTrue(this.character.RelationshipsTo(newCharacter).Contains(secondToRelationshipDescription));
        }

        [TestMethod]
        public void RelateTo_OneWayDescriptionIsUnsanitized_DescriptionIsSanitized()
        {
            // Arrange
            var newCharacter = new Character() { Name = "CharacterName" };

            // Act
            this.character.RelateTo(newCharacter, toRelationshipDescription.ToUnsanitized(), true);

            // Assert          `
            Assert.AreEqual(toRelationshipDescription.ToSanitized(), this.character.RelationshipsTo(newCharacter).Single());
        }

        [TestMethod]
        public void RelateTo_OneWayDescriptionOnlyConsistsOfIllegalCharacters_ThrowsArgumentException()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => this.character.RelateTo(new Character(), "  \0\n ", true));
            Assert.AreEqual(relationshipDescriptionParameterName, exception.ParamName);
        }
        
        [TestMethod]
        public void RelateTo_OneWayDescriptionAlreadyExists_ThrowsArgumentException()
        {
            // Arrange
            var newCharacter = new Character() { Name = "CharacterName" };
            this.character.RelateTo(newCharacter, toRelationshipDescription, true);

            // Act
            // Assert
            var exception = Assert.ThrowsException<ArgumentException>(() => this.character.RelateTo(newCharacter, toRelationshipDescription.ToUpper(), true));
            Assert.AreEqual(relationshipDescriptionParameterName, exception.ParamName);
        }

        [TestMethod]
        public void RelateTo_TwoWayDescriptionIsUnsanitized_DescriptionIsSanitized()
        {
            // Arrange
            var newCharacter = new Character() { Name = "CharacterName" };

            // Act
            this.character.RelateTo(newCharacter, toRelationshipDescription.ToUnsanitized(), fromRelationshipDescription);

            // Assert          
            Assert.AreEqual(toRelationshipDescription.ToSanitized(), this.character.RelationshipsTo(newCharacter).Single());
        }

        [TestMethod]
        public void RelateTo_TwoWayDescriptionOnlyConsistsOfIllegalCharacters_ThrowsArgumentException()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => this.character.RelateTo(new Character(), "  \0\n ", "Relation"));
            Assert.AreEqual(relationshipDescriptionParameterName, exception.ParamName);
        }

        [TestMethod]
        public void RelateTo_TwoWayReverseDescriptionIsUnsanitized_DescriptionIsSanitized()
        {
            // Arrange
            var newCharacter = new Character() { Name = "CharacterName" };

            // Act
            this.character.RelateTo(newCharacter, toRelationshipDescription, fromRelationshipDescription.ToUnsanitized());

            // Assert          
            Assert.AreEqual(fromRelationshipDescription.ToSanitized(), newCharacter.RelationshipsTo(this.character).Single());
        }

        [TestMethod]
        public void RelateTo_TwoWayReverseDescriptionOnlyConsistsOfIllegalCharacters_ThrowsArgumentException()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => this.character.RelateTo(new Character(), "Relation", "  \0\n "));
            Assert.AreEqual(reverseRelationshipDescriptionParameterName, exception.ParamName);
        }
        
        [TestMethod]
        public void RelateTo_TwoWayDescriptionAlreadyExists_ThrowsArgumentException()
        {
            // Arrange
            var newCharacter = new Character() { Name = "CharacterName" };
            this.character.RelateTo(newCharacter, toRelationshipDescription, fromRelationshipDescription);

            // Act
            // Assert
            var exception = Assert.ThrowsException<ArgumentException>(() => this.character.RelateTo(newCharacter, toRelationshipDescription.ToUpper(), "new"));
            Assert.AreEqual(relationshipDescriptionParameterName, exception.ParamName);
        }

        [TestMethod]
        public void RelateTo_TwoWayReverseDescriptionAlreadyExists_ThrowsArgumentException()
        {
            // Arrange
            var newCharacter = new Character() { Name = "CharacterName" };
            this.character.RelateTo(newCharacter, toRelationshipDescription, fromRelationshipDescription);

            // Act
            // Assert
            var exception = Assert.ThrowsException<ArgumentException>(() => this.character.RelateTo(newCharacter, "new", fromRelationshipDescription.ToUpper()));
            Assert.AreEqual(reverseRelationshipDescriptionParameterName, exception.ParamName);
        }

        [TestMethod]
        public void RelateTo_TwoWayCharacterIsNull_ThrowsArgumentNullException()
        {
            var exception = Assert.ThrowsException<ArgumentNullException>(() => this.character.RelateTo(null, toRelationshipDescription, fromRelationshipDescription));
            Assert.AreEqual(characterParameterName, exception.ParamName);
        }

        [TestMethod]
        public void RelateTo_TwoWayCharacterIsSelf_ThrowsArgumentException()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => this.character.RelateTo(this.character, toRelationshipDescription, fromRelationshipDescription));
            Assert.AreEqual(characterParameterName, exception.ParamName);
        }

        [TestMethod]
        public void RelateTo_TwoWayDescriptionIsEmpty_ThrowsArgumentException()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => this.character.RelateTo(new Character(), string.Empty, fromRelationshipDescription));
            Assert.AreEqual(relationshipDescriptionParameterName, exception.ParamName);
        }

        [TestMethod]
        public void RelateTo_TwoWayReverseDescriptionIsEmpty_ThrowsArgumentException()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => this.character.RelateTo(new Character(), toRelationshipDescription, string.Empty));
            Assert.AreEqual(reverseRelationshipDescriptionParameterName, exception.ParamName);
        }

        [TestMethod]
        public void RelateTo_TwoWayDescriptionIsNull_ThrowsArgumentNullException()
        {
            var exception = Assert.ThrowsException<ArgumentNullException>(() => this.character.RelateTo(new Character(), null, fromRelationshipDescription));
            Assert.AreEqual(relationshipDescriptionParameterName, exception.ParamName);
        }
        
        [TestMethod]
        public void RelateTo_TwoWayReverseDescriptionIsNull_ThrowsArgumentNullException()
        {
            var exception = Assert.ThrowsException<ArgumentNullException>(() => this.character.RelateTo(new Character(), toRelationshipDescription, null));
            Assert.AreEqual(reverseRelationshipDescriptionParameterName, exception.ParamName);
        }

        [TestMethod]
        public void RelateTo_TwoWayCharacterIsNew_CharactersAreRelatedToEachAuthor()
        {
            // Arrange
            var newCharacter = new Character() { Name = "CharacterName" };

            // Act
            this.character.RelateTo(newCharacter, toRelationshipDescription, fromRelationshipDescription);

            // Assert          
            Assert.AreEqual(toRelationshipDescription, this.character.RelationshipsTo(newCharacter).Single());
            Assert.AreEqual(fromRelationshipDescription, newCharacter.RelationshipsTo(this.character).Single());
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
        public void UnrelateTo_HasMultipleOneWayRelationshipsToRelatedCharacter_HasNoRelationshipsToRelatedCharacter()
        {
            // Arrange
            var relatedCharacter = new Character() { Name = "Character" };
            this.character.RelateTo(relatedCharacter, toRelationshipDescription, true);
            this.character.RelateTo(relatedCharacter, secondToRelationshipDescription, true);

            // Act
            this.character.UnrelateTo(relatedCharacter);

            // Assert          
            Assert.AreEqual(0, this.character.RelationshipsTo(relatedCharacter).Count);
        }

        [TestMethod]
        public void UnrelateTo_HasMultipleTwoWayRelationshipsToRelatedCharacter_HasNoRelationshipsToRelatedCharacterButReverseRelationsRemain()
        {
            // Arrange
            var relatedCharacter = new Character() { Name = "Character" };
            this.character.RelateTo(relatedCharacter, toRelationshipDescription, fromRelationshipDescription);
            this.character.RelateTo(relatedCharacter, secondToRelationshipDescription, secondFromRelationshipDescription);

            // Act
            this.character.UnrelateTo(relatedCharacter);

            // Assert          
            Assert.AreEqual(0, this.character.RelationshipsTo(relatedCharacter).Count);
            Assert.AreEqual(2, relatedCharacter.RelationshipsTo(this.character).Count);
            Assert.IsTrue(relatedCharacter.RelationshipsTo(this.character).Contains(fromRelationshipDescription));
            Assert.IsTrue(relatedCharacter.RelationshipsTo(this.character).Contains(secondFromRelationshipDescription));
        }

        [TestMethod]
        public void UnrelateToSpecific_CharacterIsNull_ThrowsArgumentNullException()
        {
            var exception = Assert.ThrowsException<ArgumentNullException>(() => this.character.UnrelateTo(null, fromRelationshipDescription));
            Assert.AreEqual(characterParameterName, exception.ParamName);
        }

        [TestMethod]
        public void UnrelateToSpecific_CharacterIsSelf_ThrowsArgumentException()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => this.character.UnrelateTo(this.character, fromRelationshipDescription));
            Assert.AreEqual(characterParameterName, exception.ParamName);
        }

        [TestMethod]
        public void UnrelateToSpecific_CharacterIsUnrelated_ThrowsArgumentException()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => this.character.UnrelateTo(new Character(), fromRelationshipDescription));
            Assert.AreEqual(characterParameterName, exception.ParamName);
        }

        [TestMethod]
        public void UnrelateToSpecific_RelationDescriptionIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            var relatedCharacter = new Character() { Name = "RelatedCharacter" };
            this.character.RelateTo(relatedCharacter, fromRelationshipDescription);

            // Act
            // Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => this.character.UnrelateTo(relatedCharacter, null));
            Assert.AreEqual(relationshipDescriptionParameterName, exception.ParamName);
        }

        [TestMethod]
        public void UnrelateToSpecific_RelationDescriptionIsEmpty_ThrowsArgumentException()
        {
            // Arrange
            var relatedCharacter = new Character() { Name = "RelatedCharacter" };
            this.character.RelateTo(relatedCharacter, fromRelationshipDescription);

            // Act
            // Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => this.character.UnrelateTo(relatedCharacter, string.Empty));
            Assert.AreEqual(relationshipDescriptionParameterName, exception.ParamName);
        }

        [TestMethod]
        public void UnrelateToSpecific_RelationDescriptionIsUnknown_ThrowsArgumentException()
        {
            // Arrange
            var relatedCharacter = new Character() { Name = "RelatedCharacter" };
            this.character.RelateTo(relatedCharacter, fromRelationshipDescription);

            // Act
            // Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => this.character.UnrelateTo(relatedCharacter, "UnknownRelation"));
            Assert.AreEqual(relationshipDescriptionParameterName, exception.ParamName);
        }

        [TestMethod]
        public void UnrelateToSpecific_OneWayRelationDescriptionIsKnown_RelationIsRemoved()
        {
            // Arrange
            var firstRelatedCharacter = new Character() { Name = "FirstRelatedCharacter" };
            var secondRelatedCharacter = new Character() { Name = "SecondRelatedCharacter" };
            this.character.RelateTo(firstRelatedCharacter, toRelationshipDescription, true);
            this.character.RelateTo(secondRelatedCharacter, secondToRelationshipDescription, true);

            // Act
            this.character.UnrelateTo(firstRelatedCharacter, toRelationshipDescription);

            // Assert
            Assert.AreEqual(0, this.character.RelationshipsTo(firstRelatedCharacter).Count);
            Assert.AreEqual(1, this.character.RelationshipsTo(secondRelatedCharacter).Count);
            Assert.AreEqual(secondToRelationshipDescription, this.character.RelationshipsTo(secondRelatedCharacter).Single());
        }

        [TestMethod]
        public void UnrelateToSpecific_TwoWayToRelationDescriptionIsKnown_RelationIsRemoved()
        {
            // Arrange
            var firstRelatedCharacter = new Character() { Name = "FirstRelatedCharacter" };
            var secondRelatedCharacter = new Character() { Name = "SecondRelatedCharacter" };
            this.character.RelateTo(firstRelatedCharacter, toRelationshipDescription, fromRelationshipDescription);
            this.character.RelateTo(secondRelatedCharacter, secondToRelationshipDescription, secondFromRelationshipDescription);

            // Act
            this.character.UnrelateTo(firstRelatedCharacter, toRelationshipDescription);

            // Assert
            Assert.AreEqual(0, this.character.RelationshipsTo(firstRelatedCharacter).Count);
            Assert.AreEqual(0, firstRelatedCharacter.RelationshipsTo(this.character).Count);

            Assert.AreEqual(1, this.character.RelationshipsTo(secondRelatedCharacter).Count);
            Assert.AreEqual(secondToRelationshipDescription, this.character.RelationshipsTo(secondRelatedCharacter).Single());
            
            Assert.AreEqual(1, secondRelatedCharacter.RelationshipsTo(this.character).Count);
            Assert.AreEqual(secondFromRelationshipDescription, secondRelatedCharacter.RelationshipsTo(this.character).Single());
        }

        [TestMethod]
        public void UnrelateToSpecific_TwoWayFromRelationDescriptionIsKnown_RelationIsRemoved()
        {
            // Arrange
            var firstRelatedCharacter = new Character() { Name = "FirstRelatedCharacter" };
            var secondRelatedCharacter = new Character() { Name = "SecondRelatedCharacter" };
            this.character.RelateTo(firstRelatedCharacter, toRelationshipDescription, fromRelationshipDescription);
            this.character.RelateTo(secondRelatedCharacter, secondToRelationshipDescription, secondFromRelationshipDescription);

            // Act
            this.character.UnrelateTo(firstRelatedCharacter, fromRelationshipDescription);

            // Assert
            Assert.AreEqual(0, this.character.RelationshipsTo(firstRelatedCharacter).Count);
            Assert.AreEqual(0, firstRelatedCharacter.RelationshipsTo(this.character).Count);

            Assert.AreEqual(1, this.character.RelationshipsTo(secondRelatedCharacter).Count);
            Assert.AreEqual(secondToRelationshipDescription, this.character.RelationshipsTo(secondRelatedCharacter).Single());

            Assert.AreEqual(1, secondRelatedCharacter.RelationshipsTo(this.character).Count);
            Assert.AreEqual(secondFromRelationshipDescription, secondRelatedCharacter.RelationshipsTo(this.character).Single());
        }

        #endregion

        #region RelationshipsTo
        [TestMethod]
        public void RelationshipsTo_CharacterIsNull_ThrowsArgumentNullException()
        {
            var exception = Assert.ThrowsException<ArgumentNullException>(() => this.character.RelationshipsTo(null));
            Assert.AreEqual(characterParameterName, exception.ParamName);
        }

        [TestMethod]
        public void RelationshipsTo_CharacterIsSelf_ThrowsArgumentException()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => this.character.RelationshipsTo(this.character));
            Assert.AreEqual(characterParameterName, exception.ParamName);
        }

        [TestMethod]
        public void RelationshipsTo_CharacterIsUnrelated_ReturnsNull()
        {
            // Arrange
            // Act
            var relations = this.character.RelationshipsTo(new Character());

            // Assert          
            Assert.AreEqual(0, relations.Count);
        }

        [TestMethod]
        public void RelationshipsTo_CharacterIsOneWayRelated_ReturnsRelationDescription()
        {
            // Arrange
            var newCharacter = new Character() { Name = "NewCharacter" };
            this.character.RelateTo(newCharacter, toRelationshipDescription, true);

            // Act
            var relations = this.character.RelationshipsTo(newCharacter);

            // Assert          
            Assert.AreEqual(toRelationshipDescription, relations.Single());
        }

        [TestMethod]
        public void RelationshipsTo_CharacterIsOneWayReverseRelated_ReturnsNull()
        {
            // Arrange
            var newCharacter = new Character() { Name = "NewCharacter" };
            this.character.RelateTo(newCharacter, toRelationshipDescription, true);

            // Act
            var relations = newCharacter.RelationshipsTo(this.character);

            // Assert          
            Assert.AreEqual(0, relations.Count);
        }

        [TestMethod]
        public void RelationshipsTo_CharacterIsTwoWayRelated_ReturnsToRelationDescription()
        {
            // Arrange
            var newCharacter = new Character() { Name = "NewCharacter" };
            this.character.RelateTo(newCharacter, toRelationshipDescription, fromRelationshipDescription);

            // Act
            var relations = this.character.RelationshipsTo(newCharacter);
            
            // Assert          
            Assert.AreEqual(toRelationshipDescription, relations.Single());            
        }

        [TestMethod]
        public void RelationshipsTo_CharacterIsReverseTwoWayRelated_ReturnsFromRelationDescription()
        {
            // Arrange
            var newCharacter = new Character() { Name = "NewCharacter" };
            this.character.RelateTo(newCharacter, toRelationshipDescription, fromRelationshipDescription);

            // Act
            var relations = newCharacter.RelationshipsTo(this.character);

            // Assert          
            Assert.AreEqual(fromRelationshipDescription, relations.Single());
        }
        #endregion
    }
}
