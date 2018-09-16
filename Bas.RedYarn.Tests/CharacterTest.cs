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

        
    }
}
