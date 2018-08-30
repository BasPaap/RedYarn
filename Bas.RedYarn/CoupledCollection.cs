using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Text;

namespace Bas.RedYarn
{
    sealed class CoupledCollection<OtherType, OwnerType> : Collection<OtherType>
    {
        private readonly OwnerType owner;

        private readonly PropertyInfo otherCollectionProperty;
        private readonly MethodInfo insertCoupledItemMethod;
        private readonly MethodInfo removeCoupledItemMethod;
        
        public CoupledCollection(OwnerType owner, string otherCollectionPropertyName)
        {
            this.owner = owner;

            // Get collection property for other type
            this.otherCollectionProperty = typeof(OtherType).GetProperty(otherCollectionPropertyName);

            // Get coupledItem methods on other collection type
            this.insertCoupledItemMethod = GetCoupledItemMethodInfo(nameof(InsertCoupledItem));
            this.removeCoupledItemMethod = GetCoupledItemMethodInfo(nameof(RemoveCoupledItem));
        }

        private static MethodInfo GetCoupledItemMethodInfo(string methodName)
        {
            return typeof(CoupledCollection<OwnerType, OtherType>).GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);
        }

        protected override void ClearItems()
        {
            // Remove owner from all other items' collections by calling RemoveCoupledItem on all other collections.
            foreach (var itemToRemove in this)
            {
                this.removeCoupledItemMethod.Invoke(this.otherCollectionProperty.GetValue(itemToRemove), new object[] { this.owner });
            }

            base.ClearItems();
        }

        protected override void InsertItem(int index, OtherType item)
        {
            base.InsertItem(index, item);
                        
            // Add owner to other item's collection as well by calling InsertCoupledItem on other collection.
            this.insertCoupledItemMethod.Invoke(this.otherCollectionProperty.GetValue(item), new object[] { this.owner });
        }

        protected override void RemoveItem(int index)
        {
            var item = base[index];

            base.RemoveItem(index);

            // Remove owner from other item's collection as well by calling RemoveCoupledItem on other collection.
            this.removeCoupledItemMethod.Invoke(this.otherCollectionProperty.GetValue(item), new object[] { this.owner });
        }

        protected override void SetItem(int index, OtherType item)
        {
            var originalItem = this[index];

            base.SetItem(index, item);

            // Remove owner from the original item and add owner to the new item by calling RemoveCoupledItem on the original item's collection
            // and InsertCoupledItem on the new item's collection.            
            this.removeCoupledItemMethod.Invoke(this.otherCollectionProperty.GetValue(originalItem), new object[] { this.owner });
            this.insertCoupledItemMethod.Invoke(this.otherCollectionProperty.GetValue(item), new object[] { this.owner });
        }
                
        private void InsertCoupledItem(OtherType item)
        {
            base.InsertItem(this.Count, item); // Call base.InsertItem to avoid tripping CoupledCollection.InsertItem again by calling, for instance, Add().
        }
        
        private void RemoveCoupledItem(OtherType otherOwner)
        {
            if (this.Contains(otherOwner))
            {
                base.RemoveItem(this.IndexOf(otherOwner)); // Call base.RemoveItem to avoid tripping CoupledCollection.RemoveItem.                
            }
        }
    }
}
