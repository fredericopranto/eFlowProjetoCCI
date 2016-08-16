using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;
using Microsoft.Cci;

namespace TourreauGilles.CciExplorer.Windows
{
    internal static class Utilities
    {
        public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> items)
        {
            Contract.Assert(collection != null);
            Contract.Assert(items != null);

            foreach (T item in items)
            {
                collection.Add(item);
            }
        }
    }
}
