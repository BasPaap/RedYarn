using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Bas.RedYarn.WebApp.Extensions
{
    internal static class CollectionExtensions
    {
        public static void AddRange<T>(this Collection<T> collection, IEnumerable<T> itemsToAdd)
        {
            if (itemsToAdd != null)
            {
                foreach (var item in itemsToAdd)
                {
                    collection.Add(item);
                }
            }
        }
    }
}
