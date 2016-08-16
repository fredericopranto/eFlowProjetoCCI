using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Microsoft.Cci;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.ViewModel;
using System.Diagnostics.Contracts;

namespace TourreauGilles.CciExplorer.Windows.Explorer
{
    internal class ExplorerViewModel : NotificationObject
    {
        private readonly ObservableCollection<AssemblyNodeViewModel> assemblies;
        private readonly IEventAggregator eventAggregator;

        public ExplorerViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            this.assemblies = new ObservableCollection<AssemblyNodeViewModel>();

            this.eventAggregator.GetEvent<AssemblyEvent>().Subscribe(assembly => this.AddAssembly(assembly));
            this.eventAggregator.GetEvent<CurrentObjectEvent>().Subscribe(definition => this.Select(definition));
        }

        public ObservableCollection<AssemblyNodeViewModel> Assemblies
        {
            get { return this.assemblies; }
        }

        public IEventAggregator EventAggregator
        {
            get { return this.eventAggregator; }
        }

        private AssemblyNodeViewModel AddAssembly(IAssembly assembly)
        {
            AssemblyNodeViewModel viewModel;

            viewModel = new AssemblyNodeViewModel(this, assembly);
            this.Assemblies.Add(viewModel);

            return viewModel;
        }

        private void Select(IDefinition definition)
        {
            if (NodeViewModel.CurrentSelected == null || NodeViewModel.CurrentSelected.Definition != definition)
            {
                IList<IDefinition> path;

                path = GetPath(definition);

                // Find the assembly node
                AssemblyNodeViewModel assemblyNode;

                assemblyNode = this.Assemblies.Where(a => a.Definition == path[0]).SingleOrDefault();
                if (assemblyNode == null)
                {
                    // Add the assembly
                    assemblyNode = this.AddAssembly((IAssembly)path[0]);
                }

                Select(assemblyNode, path, 1);
            }
        }

        private static void Select(INodeViewModel viewModel, IList<IDefinition> path, int index)
        {
            INodeViewModel node;

            node = viewModel.Nodes.Where(n => n.Definition == path[index]).Single();

            if (index == path.Count - 1)
            {
                node.IsSelected = true;
            }
            else
            {
                Select(node, path, index + 1);
            }
        }
        
        private static IList<IDefinition> GetPath(IDefinition definition)
        {
            IList<IDefinition> path;

            path = new List<IDefinition>();
            GetPath(definition, path);

            return path;
        }

        private static void GetPath(IDefinition definition, IList<IDefinition> path)
        {
            path.Insert(0, definition);

            if (definition is ITypeDefinitionMember)
            {
                GetPath(((ITypeDefinitionMember)definition).Container, path);
            }
            if (definition is INamespaceTypeDefinition)
            {
                GetPath(((INamespaceTypeDefinition)definition).ContainingNamespace, path);
            }
            else if (definition is INestedUnitNamespace)
            {
                GetPath(((INestedUnitNamespace)definition).ContainingUnitNamespace.Unit, path);
            }
            else if (definition is INamespaceDefinition)
            {
                GetPath((IAssembly)((INamespaceDefinition)definition).RootOwner, path);
            }
        }
    }
}
