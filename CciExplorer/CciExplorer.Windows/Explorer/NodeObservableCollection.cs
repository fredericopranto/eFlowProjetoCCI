using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;

namespace TourreauGilles.CciExplorer.Windows.Explorer
{
    internal sealed class NodeObservableCollection<TViewModel> : ObservableCollection<TViewModel>
        where TViewModel : INodeViewModel
    {
        private readonly INodeViewModel parent;

        public NodeObservableCollection(INodeViewModel parent)
        {
            Contract.Assert(parent != null);

            this.parent = parent;
        }

        protected override void InsertItem(int index, TViewModel item)
        {
            item.Parent = this.parent;

            base.InsertItem(index, item);
        }
    }
}
