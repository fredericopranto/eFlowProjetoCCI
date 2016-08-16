using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Cci;
using System.Collections.ObjectModel;

namespace TourreauGilles.CciExplorer.Windows.Explorer
{
    internal interface INodeViewModel
    {
        string Name
        {
            get;
        }

        bool IsExpanded
        {
            get;
            set;
        }

        bool IsSelected
        {
            get;
            set;
        }

        INodeViewModel Parent
        {
            get;
            set;
        }

        ExplorerViewModel Explorer
        {
            get;
        }

        ObservableCollection<INodeViewModel> Nodes
        {
            get;
        }

        IDefinition Definition
        {
            get;
        }
    }
}
