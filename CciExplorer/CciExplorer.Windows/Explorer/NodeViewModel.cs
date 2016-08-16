using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Documents;
using Microsoft.Cci;
using Microsoft.Practices.Prism.ViewModel;

namespace TourreauGilles.CciExplorer.Windows.Explorer
{
    internal abstract class NodeViewModel : NotificationObject, INodeViewModel
    {
        private ObservableCollection<INodeViewModel> nodes;
        private bool isExpanded;
        private bool isSelected;
        private static readonly ViewModelNodeFactory factory = new ViewModelNodeFactory();

        private static NodeViewModel currentSelected;
        
        protected NodeViewModel()
        {
        }

        public ViewModelNodeFactory Factory
        {
            get { return factory; }
        }

        public static NodeViewModel CurrentSelected
        {
            get { return currentSelected; }
        }

        public abstract string Name
        {
            get;
        }

        public INodeViewModel Parent
        {
            get;
            set;
        }

        public virtual ExplorerViewModel Explorer
        {
            get { return this.Parent.Explorer; }
        }

        public bool IsExpanded
        {
            get
            {
                return isExpanded;
            }

            set
            {
                if (this.isExpanded != value)
                {
                    this.isExpanded = value;
                    this.RaisePropertyChanged(() => this.IsExpanded);
                }

                // Expand all the way up to the root.
                if (this.isExpanded == true && this.Parent != null)
                {
                    this.Parent.IsExpanded = true;
                }

                // Lazy load the child items, if necessary.
                if (this.HasDummyChild)
                {
                    this.Nodes.Remove(DummyNodeViewModel.Instance);
                    this.LoadChildrenNodes();
                }
            }
        }

        public bool IsSelected
        {
            get
            {
                return isSelected;
            }

            set
            {
                if (this.isSelected != value)
                {
                    this.isSelected = value;
                    if (value == true)
                    {
                        this.Parent.IsExpanded = true;

                        currentSelected = this;
                        this.OnSelected();
                    }

                    this.RaisePropertyChanged(() => this.IsSelected);
                }
            }
        }

        protected virtual void OnSelected()
        {
        }

        /// <summary>
        /// Returns true if this object's Children have not yet been populated.
        /// </summary>
        public bool HasDummyChild
        {
            get { return this.Nodes.Count == 1 && this.Nodes[0] == DummyNodeViewModel.Instance; }
        }

        public ObservableCollection<INodeViewModel> Nodes
        {
            get
            {
                if (this.nodes == null)
                {
                    this.nodes = new NodeObservableCollection<INodeViewModel>(this);
                    this.LoadChildrenNodes();
                }

                return this.nodes;
            }
        }

        protected void AddNode(INamedEntity item)
        {
            this.Nodes.Add(this.Factory.CreateViewModel(item));
        }

        protected void AddNodes<T>(IEnumerable<T> items)
            where T : INamedEntity
        {
            foreach (INamedEntity item in items)
            {
                this.AddNode(item);
            }
        }

        protected virtual void LoadChildrenNodes()
        {
        }

        public abstract IDefinition Definition
        {
            get;
        }

        private class DummyNodeViewModel : NodeViewModel
        {
            private static readonly DummyNodeViewModel instance = new DummyNodeViewModel();

            private DummyNodeViewModel()
                : base()
            {
            }

            public override IDefinition Definition
            {
                get { return Dummy.Type; }
            }

            public static DummyNodeViewModel Instance
            {
                get { return instance; }
            }

            public override string Name
            {
                get { return string.Empty; }
            }
        }
    }
}
