using Bas.RedYarn.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bas.RedYarn
{
    [TestClass]
    public class StorylineTest
    {
        private Storyline storyline;

        [TestInitialize]
        public void Initialize()
        {
            this.storyline = new Storyline();
        }

        #region ToString
        [TestMethod]
        public void ToString_NameIsNotEmpty_ReturnsName()
        {
            ToStringHelper.ToString_NameIsNotEmpty_ReturnsName(this.storyline);
        }

        [TestMethod]
        public void ToString_NameIsEmpty_ReturnsClassName()
        {
            ToStringHelper.ToString_NameIsEmpty_ReturnsClassName(this.storyline);
        }
        #endregion
        
        #region Characters property
        [TestMethod]
        public void CharactersAdd_NewCharacter_StorylineContainsCharacter()
        {
            var character = new Character() { Name = "Character" };
            ManyToManyCollectionHelper.CollectionAdd_NewItem_RelatedCollectionContainsThis(this.storyline, character, this.storyline.Characters, character.Storylines);
        }

        [TestMethod]
        public void CharactersInsert_NewCharacter_StorylineContainsCharacter()
        {
            var character = new Character() { Name = "Character" };
            ManyToManyCollectionHelper.CollectionInsert_NewItem_RelatedCollectionContainsThis(this.storyline, character, this.storyline.Characters, character.Storylines);
        }

        [TestMethod]
        public void CharactersClear_CharacterContainsStoryline_StorylineIsRemovedFromCharacter()
        {
            var character = new Character() { Name = "Character" };
            ManyToManyCollectionHelper.CollectionClear_TestedObjectCollectionContainsRelatedObject_TestedObjectIsRemovedFromRelatedCollection(this.storyline, character, this.storyline.Characters, character.Storylines);
        }

        [TestMethod]
        public void CharactersRemove_CharacterContainsStoryline_StorylineIsRemovedFromCharacter()
        {
            var character = new Character() { Name = "Character" };
            ManyToManyCollectionHelper.CollectionRemove_TestedObjectCollectionContainsRelatedObject_TestedObjectIsRemovedFromRelatedCollection(this.storyline, character, this.storyline.Characters, character.Storylines);
        }

        [TestMethod]
        public void CharactersRemoveAt_CharacterContainsStoryline_StorylineIsRemovedFromCharacter()
        {
            var character = new Character() { Name = "Character" };
            ManyToManyCollectionHelper.CollectionRemoveAt_TestedObjectCollectionContainsRelatedObject_TestedObjectIsRemovedFromRelatedCollection(this.storyline, character, this.storyline.Characters, character.Storylines);
        }

        [TestMethod]
        public void CharactersSet_CharacterContainsStoryline_StorylineIsRemovedFromOldCharacterAndAddedToNewCharacter()
        {
            var character = new Character() { Name = "Character" };
            var newCharacter = new Character() { Name = "NewCharacter" };

            ManyToManyCollectionHelper.CollectionSet_TestedObjectCollectionContainsRelatedObject_TestedObjectIsReplacedInRelatedCollection(this.storyline, character, newCharacter, this.storyline.Characters, character.Storylines, newCharacter.Storylines);
        }

        #endregion

        #region Authors property
        [TestMethod]
        public void AuthorsAdd_NewAuthor_AuthorContainsStoryline()
        {
            var author = new Author() { Name = "Author" };
            ManyToManyCollectionHelper.CollectionAdd_NewItem_RelatedCollectionContainsThis(this.storyline, author, this.storyline.Authors, author.Storylines);
        }

        [TestMethod]
        public void AuthorsInsert_NewAuthor_AuthorContainsStoryline()
        {
            var author = new Author() { Name = "Author" };
            ManyToManyCollectionHelper.CollectionInsert_NewItem_RelatedCollectionContainsThis(this.storyline, author, this.storyline.Authors, author.Storylines);
        }

        [TestMethod]
        public void AuthorsClear_AuthorContainsStoryline_StorylineIsRemovedFromAuthor()
        {
            var author = new Author() { Name = "Author" };
            ManyToManyCollectionHelper.CollectionClear_TestedObjectCollectionContainsRelatedObject_TestedObjectIsRemovedFromRelatedCollection(this.storyline, author, this.storyline.Authors, author.Storylines);
        }

        [TestMethod]
        public void AuthorsRemove_AuthorContainsStoryline_StorylineIsRemovedFromAuthor()
        {
            var author = new Author() { Name = "Author" };
            ManyToManyCollectionHelper.CollectionRemove_TestedObjectCollectionContainsRelatedObject_TestedObjectIsRemovedFromRelatedCollection(this.storyline, author, this.storyline.Authors, author.Storylines);
        }

        [TestMethod]
        public void AuthorsRemoveAt_AuthorContainsStoryline_StorylineIsRemovedFromAuthor()
        {
            var author = new Author() { Name = "Author" };
            ManyToManyCollectionHelper.CollectionRemoveAt_TestedObjectCollectionContainsRelatedObject_TestedObjectIsRemovedFromRelatedCollection(this.storyline, author, this.storyline.Authors, author.Storylines);
        }
        
        [TestMethod]
        public void AuthorsSet_AuthorContainsStoryline_StorylineIsRemovedFromOldAuthorAndAddedToNewAuthor()
        {
            var author = new Author() { Name = "Author" };
            var newAuthor = new Author() { Name = "NewAuthor" };

            ManyToManyCollectionHelper.CollectionSet_TestedObjectCollectionContainsRelatedObject_TestedObjectIsReplacedInRelatedCollection(this.storyline, author, newAuthor, this.storyline.Authors, author.Storylines, newAuthor.Storylines);
        }
        #endregion
    }
}
