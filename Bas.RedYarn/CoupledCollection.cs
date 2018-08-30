using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Text;

namespace Bas.RedYarn
{
    /// <summary>
    /// CoupledCollection is a collection of objects that is coupled to a second collection of objects. Whenever an item is added to the coupledcollection, 
    /// the instance that coupledcollection belongs to is added to the item's own coupledcollection. This enables many-to-many relationships between objects.
    /// </summary>
    /// <typeparam name="OtherType">The type of the items this collection contains.</typeparam>
    /// <typeparam name="OwnerType">The type this collection is a member of.</typeparam>
    sealed class CoupledCollection<OtherType, OwnerType> : Collection<OtherType>
    {
        private readonly OwnerType owner; // We need a reference to whoever this instance is a member of in order to add or remove it to the other coupledcollection.

        private readonly PropertyInfo otherCollectionProperty; // PropertyInfo about the property that holds the other CoupledCollection.
        private readonly MethodInfo insertCoupledItemMethod;   // Reflected method on the other CoupledCollection via which we can add items.
        private readonly MethodInfo removeCoupledItemMethod;   // Reflected method on the other CoupledCollection via which we can add items.

        /// <summary>
        /// Creates an instance of CoupledCollection.
        /// </summary>
        /// <param name="owner">The instance this collection is a member of.</param>
        /// <param name="otherCollectionPropertyName">The property name of the other CoupledCollection</param>
        public CoupledCollection(OwnerType owner, string otherCollectionPropertyName)
        {
            this.owner = owner;

            // Get collection property for other type
            this.otherCollectionProperty = typeof(OtherType).GetProperty(otherCollectionPropertyName);

            // Get coupledItem methods on other collection type
            this.insertCoupledItemMethod = GetCoupledItemMethodInfo(nameof(InsertCoupledItem));
            this.removeCoupledItemMethod = GetCoupledItemMethodInfo(nameof(RemoveCoupledItem));            
        }

        /// <summary>
        /// Returns a reflected method (with the name specified in methodName) on the type this collection contains.
        /// </summary>
        /// <param name="methodName">The name of the method on OtherType.</param>
        /// <returns></returns>
        private static MethodInfo GetCoupledItemMethodInfo(string methodName)
        {
            return typeof(CoupledCollection<OwnerType, OtherType>).GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);
        }


        /// <summary>
        /// Removes all elements from the CoupledCollection and all references to the owner from the other CoupledCollections.
        /// </summary>
        protected override void ClearItems()
        {
            // Remove owner from all other items' collections by calling RemoveCoupledItem on all other collections.
            foreach (var itemToRemove in this)
            {
                this.removeCoupledItemMethod.Invoke(this.otherCollectionProperty.GetValue(itemToRemove), new object[] { this.owner });
            }

            // Clear this collection.
            base.ClearItems();            
        }

        /// <summary>
        /// Inserts an element into the CoupledCollection at the specified index and adds the owner to that item's CoupledCollection.
        /// </summary>
        /// <param name="index">The zero-based index at which the item should be inserted.</param>
        /// <param name="item">The object to insert.</param>
        protected override void InsertItem(int index, OtherType item)
        {
            // Insert the item in this collection.
            base.InsertItem(index, item);
                        
            // Add owner to other item's collection as well by calling InsertCoupledItem on other collection.
            this.insertCoupledItemMethod.Invoke(this.otherCollectionProperty.GetValue(item), new object[] { this.owner });
        }

        /// <summary>
        /// Removes the element at the specified index of the CoupledCollection, and removes the owner from that element's CoupledCollection.
        /// </summary>
        /// <param name="index">The zero-based index of the element to remove.</param>
        protected override void RemoveItem(int index)
        {
            var item = base[index]; // Remember which item gets removed
            base.RemoveItem(index); // Remove the item from the collection

            // Remove owner from the removed item's collection as well by calling RemoveCoupledItem on other collection.
            this.removeCoupledItemMethod.Invoke(this.otherCollectionProperty.GetValue(item), new object[] { this.owner });
        }

        /// <summary>
        /// Replaces the element at the specified index, removes the owner from the replaced element's CoupledCollection and adds the owner to the replacing element's CoupledCollection.
        /// </summary>
        /// <param name="index">The zero-based index of the element to replace.</param>
        /// <param name="item">The new value for the element at the specified index.</param>
        protected override void SetItem(int index, OtherType item)
        {
            var originalItem = this[index]; // Remember which item gets replaced
            base.SetItem(index, item); // Replace the item

            // Remove owner from the original item and add owner to the new item by calling RemoveCoupledItem on the replaced item's collection
            // and InsertCoupledItem on the new item's collection.            
            this.removeCoupledItemMethod.Invoke(this.otherCollectionProperty.GetValue(originalItem), new object[] { this.owner });
            this.insertCoupledItemMethod.Invoke(this.otherCollectionProperty.GetValue(item), new object[] { this.owner });
        }
                
        /// <summary>
        /// Adds an item to this CoupledCollection without triggering any new calls to this method.
        /// </summary>
        /// <param name="item">The item to add to the CoupledCollection.</param>
        private void InsertCoupledItem(OtherType item)
        {
            base.InsertItem(this.Count, item); // Call base.InsertItem to avoid tripping CoupledCollection.InsertItem again by calling, for instance, Add().
        }
        
        /// <summary>
        /// Removes an item from this CoupledCollection without triggering any new calls to this method.
        /// </summary>
        /// <param name="item">the item to remove from this CoupledCollection.</param>
        private void RemoveCoupledItem(OtherType item)
        {
            if (this.Contains(item))
            {
                base.RemoveItem(this.IndexOf(item)); // Call base.RemoveItem to avoid tripping CoupledCollection.RemoveItem.                
            }
        }
    }
}
