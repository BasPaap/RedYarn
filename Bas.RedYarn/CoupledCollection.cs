using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Text;

namespace Bas.RedYarn
{
    sealed class CoupledCollection<OtherType, OwnerType> : Collection<OtherType>
    {
        private OwnerType owner;
        private string otherCollectionPropertyName;

        public CoupledCollection(OwnerType owner, string otherCollectionPropertyName)
        {
            this.owner = owner;
            this.otherCollectionPropertyName = otherCollectionPropertyName;                        
        }

        protected override void ClearItems()
        {
            base.ClearItems();
        }

        protected override void InsertItem(int index, OtherType item)
        {
            base.InsertItem(index, item);

            // Get collection property for other type
            var otherCollectionProperty = item.GetType().GetProperty(this.otherCollectionPropertyName);

            // Get InsertCoupledItem on other collection
            var insertCoupledItemMethod = typeof(CoupledCollection<OwnerType, OtherType>).GetMethod(nameof(InsertCoupledItem),
                                                                                                    BindingFlags.NonPublic | BindingFlags.Instance);
            
            // Call InsertCoupledItem on other collection with owner as argument.
            insertCoupledItemMethod.Invoke(otherCollectionProperty.GetValue(item), new object[] { this.owner });
        }

        protected override void RemoveItem(int index)
        {
            base.RemoveItem(index);
        }

        protected override void SetItem(int index, OtherType item)
        {
            base.SetItem(index, item);
        }

        private void ClearCoupledItems()
        {
            throw new NotImplementedException();
        }
        
        private void InsertCoupledItem(OtherType item)
        {
            base.InsertItem(base.Count, item);
        }
        
        private void RemoveCoupledItem()
        {
            throw new NotImplementedException();
        }

        private void SetCoupledItem()
        {
            throw new NotImplementedException();
        }
    }
}
