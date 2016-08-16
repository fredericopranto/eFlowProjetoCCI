using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Cci;
using TourreauGilles.CciExplorer.CodeModel;

namespace TourreauGilles.CciExplorer.Windows.Explorer
{
    internal class MethodNodeViewModel : MemberNodeViewModel<IMethodDefinition>
    {
        private readonly string name;

        internal MethodNodeViewModel(IMethodDefinition method)
            : base(method)
        {
            this.name = method.GetDisplayName();
        }

        public override string Name
        {
            get { return this.name; }
        }

        public override ITypeReference Type
        {
            get { return (ITypeReference)this.Member.Type; }
        }
    }
}
