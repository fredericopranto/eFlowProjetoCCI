using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Cci;
using TourreauGilles.CciExplorer.CodeModel;

namespace TourreauGilles.CciExplorer.Windows.Explorer
{
    internal class NamespaceNodeViewModel : NodeViewModel
    {
        private readonly INamespaceDefinition ns;

        internal NamespaceNodeViewModel(INamespaceDefinition ns)
            : base()
        {
            this.ns = ns;
        }

        public INamespaceDefinition Namespace
        {
            get { return this.ns; }
        }

        public override IDefinition Definition
        {
            get { return this.Namespace; }
        }

        public override string Name
        {
            get { return this.ns.GetDisplayName(); }
        }

        protected override void LoadChildrenNodes()
        {
            this.AddNodes(this.Namespace.Members.Where(m => m is INamespaceDefinition == false).OrderBy(m => m.GetDisplayName()));
        }
    }
}
