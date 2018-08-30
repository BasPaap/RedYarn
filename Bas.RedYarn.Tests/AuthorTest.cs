using Bas.RedYarn.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bas.RedYarn
{
    [TestClass]
    public class AuthorTest
    {
        private Author author;

        [TestInitialize]
        public void Initialize()
        {
            this.author = new Author();
        }

        #region ToString
        [TestMethod]
        public void ToString_NameIsNotEmpty_ReturnsName()
        {
            ToStringHelper.ToString_NameIsNotEmpty_ReturnsName(this.author);
        }

        [TestMethod]
        public void ToString_NameIsEmpty_ReturnsClassName()
        {
            ToStringHelper.ToString_NameIsEmpty_ReturnsClassName(this.author);
        }
        #endregion


        #region Storylines property
        [TestMethod]
        public void StorylinesAdd_NewStoryline_StorylineContainsAuthor()
        {
            var storyline = new Storyline() { Name = "Storyline" };
            ManyToManyCollectionHelper.CollectionAdd_NewItem_RelatedCollectionContainsThis(this.author, storyline, this.author.Storylines, storyline.Authors);
        }

        [TestMethod]
        public void StorylinesInsert_NewStoryline_StorylineContainsAuthor()
        {
            var storyline = new Storyline() { Name = "Storyline" };
            ManyToManyCollectionHelper.CollectionInsert_NewItem_RelatedCollectionContainsThis(this.author, storyline, this.author.Storylines, storyline.Authors);
        }

        [TestMethod]
        public void StorylinesClear_StorylineContainsAuthor_AuthorIsRemovedFromStoryline()
        {
            var storyline = new Storyline() { Name = "Storyline" };
            ManyToManyCollectionHelper.CollectionClear_TestedObjectCollectionContainsRelatedObject_TestedObjectIsRemovedFromRelatedCollection(this.author, storyline, this.author.Storylines, storyline.Authors);
        }

        [TestMethod]
        public void StorylinesRemove_StorylineContainsAuthor_AuthorIsRemovedFromStoryline()
        {
            var storyline = new Storyline() { Name = "Storyline" };
            ManyToManyCollectionHelper.CollectionRemove_TestedObjectCollectionContainsRelatedObject_TestedObjectIsRemovedFromRelatedCollection(this.author, storyline, this.author.Storylines, storyline.Authors);
        }

        [TestMethod]
        public void StorylinesRemoveAt_StorylineContainsAuthor_AuthorIsRemovedFromStoryline()
        {
            var storyline = new Storyline() { Name = "Storyline" };
            ManyToManyCollectionHelper.CollectionRemoveAt_TestedObjectCollectionContainsRelatedObject_TestedObjectIsRemovedFromRelatedCollection(this.author, storyline, this.author.Storylines, storyline.Authors);
        }

        [TestMethod]
        public void StorylinesSet_StorylineContainsAuthor_AuthorIsRemovedFromOldStorylineAndAddedToNewStoryline()
        {
            var storyline = new Storyline() { Name = "Storyline" };
            var newStoryline = new Storyline() { Name = "NewStoryline" };

            ManyToManyCollectionHelper.CollectionSet_TestedObjectCollectionContainsRelatedObject_TestedObjectIsReplacedInRelatedCollection(this.author, storyline, newStoryline, this.author.Storylines, storyline.Authors, newStoryline.Authors);
        }

        #endregion

        #region Characters property
        [TestMethod]
        public void CharactersAdd_NewCharacter_AuthorContainsCharacter()
        {
            var character = new Character() { Name = "Character" };
            ManyToManyCollectionHelper.CollectionAdd_NewItem_RelatedCollectionContainsThis(this.author, character, this.author.Characters, character.Authors);
        }

        [TestMethod]
        public void CharactersInsert_NewCharacter_AuthorContainsCharacter()
        {
            var character = new Character() { Name = "Character" };
            ManyToManyCollectionHelper.CollectionInsert_NewItem_RelatedCollectionContainsThis(this.author, character, this.author.Characters, character.Authors);
        }

        [TestMethod]
        public void CharactersClear_CharacterContainsAuthor_AuthorIsRemovedFromCharacter()
        {
            var character = new Character() { Name = "Character" };
            ManyToManyCollectionHelper.CollectionClear_TestedObjectCollectionContainsRelatedObject_TestedObjectIsRemovedFromRelatedCollection(this.author, character, this.author.Characters, character.Authors);
        }

        [TestMethod]
        public void CharactersRemove_CharacterContainsAuthor_AuthorIsRemovedFromCharacter()
        {
            var character = new Character() { Name = "Character" };
            ManyToManyCollectionHelper.CollectionRemove_TestedObjectCollectionContainsRelatedObject_TestedObjectIsRemovedFromRelatedCollection(this.author, character, this.author.Characters, character.Authors);
        }

        [TestMethod]
        public void CharactersRemoveAt_CharacterContainsAuthor_AuthorIsRemovedFromCharacter()
        {
            var character = new Character() { Name = "Character" };
            ManyToManyCollectionHelper.CollectionRemoveAt_TestedObjectCollectionContainsRelatedObject_TestedObjectIsRemovedFromRelatedCollection(this.author, character, this.author.Characters, character.Authors);
        }

        [TestMethod]
        public void CharactersSet_CharacterContainsAuthor_AuthorIsRemovedFromOldCharacterAndAddedToNewCharacter()
        {
            var character = new Character() { Name = "Character" };
            var newCharacter = new Character() { Name = "NewCharacter" };

            ManyToManyCollectionHelper.CollectionSet_TestedObjectCollectionContainsRelatedObject_TestedObjectIsReplacedInRelatedCollection(this.author, character, newCharacter, this.author.Characters, character.Authors, newCharacter.Authors);
        }

        #endregion

    }
}
