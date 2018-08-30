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

        private PropertyInfo otherCollectionProperty;
        private MethodInfo clearCoupledItemsMethod;
        private MethodInfo insertCoupledItemMethod;
        private MethodInfo removeCoupledItemMethod;
        private MethodInfo setCoupledItemMethod;

        public CoupledCollection(OwnerType owner, string otherCollectionPropertyName)
        {
            this.owner = owner;

            // Get collection property for other type
            this.otherCollectionProperty = typeof(OtherType).GetProperty(otherCollectionPropertyName);

            // Get coupledItem methods on other collection type
            this.clearCoupledItemsMethod = typeof(CoupledCollection<OwnerType, OtherType>).GetMethod(nameof(ClearCoupledItems),
                                                                                                    BindingFlags.NonPublic | BindingFlags.Instance);
            this.insertCoupledItemMethod = typeof(CoupledCollection<OwnerType, OtherType>).GetMethod(nameof(InsertCoupledItem),
                                                                                                    BindingFlags.NonPublic | BindingFlags.Instance);
            this.removeCoupledItemMethod = typeof(CoupledCollection<OwnerType, OtherType>).GetMethod(nameof(RemoveCoupledItem),
                                                                                                    BindingFlags.NonPublic | BindingFlags.Instance);
            this.setCoupledItemMethod = typeof(CoupledCollection<OwnerType, OtherType>).GetMethod(nameof(SetCoupledItem),
                                                                                                    BindingFlags.NonPublic | BindingFlags.Instance);
        }

        protected override void ClearItems()
        {
            base.ClearItems();
        }

        protected override void InsertItem(int index, OtherType item)
        {
            base.InsertItem(index, item);
                        
            // Call InsertCoupledItem on other collection with owner as argument.
            this.insertCoupledItemMethod.Invoke(this.otherCollectionProperty.GetValue(item), new object[] { this.owner });
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
