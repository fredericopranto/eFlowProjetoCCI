using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Microsoft.Cci;
using TourreauGilles.CciExplorer.CodeModel;

namespace TourreauGilles.CciExplorer.Windows.Explorer
{
    internal class AssemblyNodeViewModel : NodeViewModel
    {
        private readonly IAssembly assembly;
        private readonly ExplorerViewModel explorer;

        public AssemblyNodeViewModel(ExplorerViewModel explorer, IAssembly assembly)
            : base()
        {
            this.explorer = explorer;
            this.assembly = assembly;
        }

        public override string Name
        {
            get { return this.assembly.Name.Value; }
        }

        public IAssembly Assembly
        {
            get { return this.assembly; }
        }

        public override IDefinition Definition
        {
            get { return this.Assembly; }
        }

        public override ExplorerViewModel Explorer
        {
            get { return this.explorer; }
        }

        protected override void LoadChildrenNodes()
        {
            this.AddNodes(GetNamespaces(this.Assembly.NamespaceRoot).OrderBy(ns => ns.GetDisplayName()));

            base.LoadChildrenNodes();
        }

        private static IEnumerable<INamespaceDefinition> GetNamespaces(INamespaceDefinition parent)
        {
            INamespaceDefinition[] children;

            children = parent.Members.OfType<INamespaceDefinition>().ToArray();

            if (parent.Members.Where(m => m is INamespaceDefinition == false).Any() == true)
            {
                yield return parent;
            }

            if (children.Length > 0)
            {
                foreach (INamespaceDefinition ns in children.SelectMany(child => GetNamespaces(child)))
                {
                    yield return ns;
                }
            }
        }
    }
}
