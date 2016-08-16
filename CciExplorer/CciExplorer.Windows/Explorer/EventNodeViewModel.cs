namespace TourreauGilles.CciExplorer.Windows.Explorer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Cci;

    internal class EventNodeViewModel : MemberNodeViewModel<IEventDefinition>
    {
        internal EventNodeViewModel(IEventDefinition eventDefinition)
            : base(eventDefinition)
        {
        }

        public override ITypeReference Type
        {
            get { return (ITypeReference)this.Member.Type; }
        }
    }
}
