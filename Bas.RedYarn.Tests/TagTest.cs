using Bas.RedYarn.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bas.RedYarn
{
    [TestClass]
    public class TagTest
    {
        private Tag tag;

        [TestInitialize]
        public void Initialize()
        {
            this.tag = new Tag();
        }

        #region ToString
        [TestMethod]
        public void ToString_NameIsNotEmpty_ReturnsName()
        {
            ToStringHelper.ToString_NameIsNotEmpty_ReturnsName(this.tag);
        }

        [TestMethod]
        public void ToString_NameIsEmpty_ReturnsClassName()
        {
            ToStringHelper.ToString_NameIsEmpty_ReturnsClassName(this.tag);
        }
        #endregion
        
        #region Characters property
        [TestMethod]
        public void CharactersAdd_NewCharacter_TagContainsCharacter()
        {
            var character = new Character() { Name = "Character" };
            ManyToManyCollectionHelper.CollectionAdd_NewItem_RelatedCollectionContainsThis(this.tag, character, this.tag.Characters, character.Tags);
        }

        [TestMethod]
        public void CharactersInsert_NewCharacter_TagContainsCharacter()
        {
            var character = new Character() { Name = "Character" };
            ManyToManyCollectionHelper.CollectionInsert_NewItem_RelatedCollectionContainsThis(this.tag, character, this.tag.Characters, character.Tags);
        }

        [TestMethod]
        public void CharactersClear_CharacterContainsTag_TagIsRemovedFromCharacter()
        {
            var character = new Character() { Name = "Character" };
            ManyToManyCollectionHelper.CollectionClear_TestedObjectCollectionContainsRelatedObject_TestedObjectIsRemovedFromRelatedCollection(this.tag, character, this.tag.Characters, character.Tags);
        }

        [TestMethod]
        public void CharactersRemove_CharacterContainsTag_TagIsRemovedFromCharacter()
        {
            var character = new Character() { Name = "Character" };
            ManyToManyCollectionHelper.CollectionRemove_TestedObjectCollectionContainsRelatedObject_TestedObjectIsRemovedFromRelatedCollection(this.tag, character, this.tag.Characters, character.Tags);
        }

        [TestMethod]
        public void CharactersRemoveAt_CharacterContainsTag_TagIsRemovedFromCharacter()
        {
            var character = new Character() { Name = "Character" };
            ManyToManyCollectionHelper.CollectionRemoveAt_TestedObjectCollectionContainsRelatedObject_TestedObjectIsRemovedFromRelatedCollection(this.tag, character, this.tag.Characters, character.Tags);
        }
        #endregion
    }
}
