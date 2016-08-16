using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Cci;
using TourreauGilles.CciExplorer.CodeModel;

namespace TourreauGilles.CciExplorer.Windows.Explorer
{
    internal class PropertyNodeViewModel : MemberNodeViewModel<IPropertyDefinition>
    {
        private string name;

        internal PropertyNodeViewModel(IPropertyDefinition property)
            : base(property)
        {
        }

        public override ITypeReference Type
        {
            get { return (ITypeReference)this.Member.Type; }
        }

        public override string Name
        {
            get
            {
                if (this.name == null)
                {
                    StringBuilder sb;
                    IParameterDefinition[] parameters;

                    sb = new StringBuilder();
                    sb.Append(this.Member.Name.Value);

                    parameters = this.Member.Parameters.ToArray();
                    if (parameters.Length > 0)
                    {
                        sb.Append("[");
                        sb.Append(parameters[0].Type.GetDisplayName());

                        for (int i = 1; i < parameters.Length; i++)
                        {
                            sb.Append(", ");
                            sb.Append(parameters[i].Type.GetDisplayName());
                        }

                        sb.Append("]");
                    }

                    sb.Append(" : ");
                    sb.Append(this.Type.GetDisplayName());

                    this.name = sb.ToString();
                }

                return this.name;
            }
        }

        protected override void LoadChildrenNodes()
        {
            this.AddNodes(this.Member.Accessors);

            base.LoadChildrenNodes();
        }
    }
}
