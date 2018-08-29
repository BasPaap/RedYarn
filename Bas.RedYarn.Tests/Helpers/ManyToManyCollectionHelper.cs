using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Bas.RedYarn.Helpers
{
    static class ManyToManyCollectionHelper
    {
        public static void CollectionAdd_NewItem_RelatedCollectionContainsThis<TestedType, RelatedType>(TestedType testedObject, RelatedType relatedObject, Collection<RelatedType> collectionOnTestedObject, Collection<TestedType> collectionOnRelatedObject)
        {
            // Arrange        
            // Act
            collectionOnTestedObject.Add(relatedObject);
                        
            // Assert          
            Assert.AreSame(testedObject, collectionOnRelatedObject[0]);
        }

        public static void CollectionInsert_NewItem_RelatedCollectionContainsThis<TestedType, RelatedType>(TestedType testedObject, RelatedType relatedObject, Collection<RelatedType> collectionOnTestedObject, Collection<TestedType> collectionOnRelatedObject)
        {
            // Arrange
            // Act
            collectionOnTestedObject.Insert(0, relatedObject);

            // Assert          
            Assert.AreSame(testedObject, collectionOnRelatedObject[0]);
        }


        public static void CollectionClear_TestedObjectCollectionContainsRelatedObject_TestedObjectIsRemovedFromRelatedCollection<TestedType, RelatedType>(TestedType testedObject, RelatedType relatedObject, Collection<RelatedType> collectionOnTestedObject, Collection<TestedType> collectionOnRelatedObject)
        {
            // Arrange
            collectionOnTestedObject.Add(relatedObject);

            // Act
            collectionOnTestedObject.Clear();

            // Assert          
            Assert.AreEqual(0, collectionOnRelatedObject.Count);
        }

        public static void CollectionRemove_TestedObjectCollectionContainsRelatedObject_TestedObjectIsRemovedFromRelatedCollection<TestedType, RelatedType>(TestedType testedObject, RelatedType relatedObject, Collection<RelatedType> collectionOnTestedObject, Collection<TestedType> collectionOnRelatedObject)
        {
            // Arrange
            collectionOnTestedObject.Add(relatedObject);

            // Act
            collectionOnTestedObject.Remove(relatedObject);

            // Assert          
            Assert.AreEqual(0, collectionOnRelatedObject.Count);
        }

        public static void CollectionRemoveAt_TestedObjectCollectionContainsRelatedObject_TestedObjectIsRemovedFromRelatedCollection<TestedType, RelatedType>(TestedType testedObject, RelatedType relatedObject, Collection<RelatedType> collectionOnTestedObject, Collection<TestedType> collectionOnRelatedObject)
        {
            // Arrange
            collectionOnTestedObject.Add(relatedObject);

            // Act
            collectionOnTestedObject.RemoveAt(0);

            // Assert          
            Assert.AreEqual(0, collectionOnRelatedObject.Count);
        }
    }
}
