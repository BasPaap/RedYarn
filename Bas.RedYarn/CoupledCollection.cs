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
        private readonly MethodInfo clearCoupledItemsMethod;
        private readonly MethodInfo insertCoupledItemMethod;
        private readonly MethodInfo removeCoupledItemMethod;
        private readonly MethodInfo setCoupledItemMethod;

        public CoupledCollection(OwnerType owner, string otherCollectionPropertyName)
        {
            this.owner = owner;

            // Get collection property for other type
            this.otherCollectionProperty = typeof(OtherType).GetProperty(otherCollectionPropertyName);

            // Get coupledItem methods on other collection type
            this.clearCoupledItemsMethod = GetCoupledItemMethod(nameof(ClearCoupledItems));
            this.insertCoupledItemMethod = GetCoupledItemMethod(nameof(InsertCoupledItem));
            this.removeCoupledItemMethod = GetCoupledItemMethod(nameof(RemoveCoupledItem));
            this.setCoupledItemMethod = GetCoupledItemMethod(nameof(SetCoupledItem));
        }

        private static MethodInfo GetCoupledItemMethod(string methodName)
        {
            return typeof(CoupledCollection<OwnerType, OtherType>).GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);
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
