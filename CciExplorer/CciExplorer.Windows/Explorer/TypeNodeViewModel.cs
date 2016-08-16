using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Cci;
using TourreauGilles.CciExplorer.CodeModel;

namespace TourreauGilles.CciExplorer.Windows.Explorer
{
    internal class TypeNodeViewModel : NodeViewModel
    {
        private readonly ITypeDefinition type;
        private readonly string name;

        internal TypeNodeViewModel(ITypeDefinition type)
        {
            this.type = type;
            this.name = type.GetDisplayName();
        }

        public ITypeDefinition Type
        {
            get { return this.type; }
        }

        public override IDefinition Definition
        {
            get { return this.Type; }
        }

        public override string Name
        {
            get { return this.name; }
        }

        protected override void LoadChildrenNodes()
        {
            this.AddNodes(this.Type.Members.OfType<INestedTypeDefinition>().OrderBy(f => f.GetDisplayName()));
            this.AddNodes(this.Type.Members.OfType<IFieldDefinition>().OrderBy(f => f.Name.Value));
            this.AddNodes(this.Type.Members.OfType<IMethodDefinition>().Where(m => m.IsConstructor == true).OrderBy(m => m.Name.Value));
            this.AddNodes(this.Type.Members.OfType<IMethodDefinition>().Where(m => m.IsSpecialName == false).OrderBy(m => m.Name.Value));
            this.AddNodes(this.Type.Members.OfType<IPropertyDefinition>().OrderBy(p => p.Name.Value));
            this.AddNodes(this.Type.Members.OfType<IEventDefinition>().OrderBy(e => e.Name.Value));

            base.LoadChildrenNodes();
        }

        protected override void OnSelected()
        {
            this.Explorer.EventAggregator.GetEvent<CurrentObjectEvent>().Publish(this.Type);
        }
    }
}
