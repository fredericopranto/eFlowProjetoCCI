using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Cci;

namespace TourreauGilles.CciExplorer.Windows.Explorer
{
    internal class FieldNodeViewModel : MemberNodeViewModel<IFieldDefinition>
    {
        internal FieldNodeViewModel(IFieldDefinition field)
            : base(field)
        {
        }

        public override ITypeReference Type
        {
            get { return this.Member.Type; }
        }
    }
}
