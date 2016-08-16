using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Documents;
using Microsoft.Cci;
using TourreauGilles.CciExplorer.CSharp;
using TourreauGilles.CciExplorer.CodeModel;

namespace TourreauGilles.CciExplorer.Windows.Explorer
{
    internal abstract class MemberNodeViewModel<TMemberDefinition> : NodeViewModel
        where TMemberDefinition : ITypeDefinitionMember
    {
        private readonly TMemberDefinition member;
        private string name;
        
        protected MemberNodeViewModel(TMemberDefinition member)
        {
            this.member = member;
        }

        public TMemberDefinition Member
        {
            get { return this.member; }
        }

        public override IDefinition Definition
        {
            get { return this.Member; }
        }

        public override string Name
        {
            get
            {
                if (this.name == null)
                {
                    this.name = string.Format("{0} : {1}", this.member.Name.Value, this.Type.GetDisplayName());
                }

                return this.name;
            }
        }

        public abstract ITypeReference Type
        {
            get;
        }

        public TypeMemberVisibility Visibility
        {
            get { return this.Member.Visibility; }
        }

        protected override void OnSelected()
        {
            this.Explorer.EventAggregator.GetEvent<CurrentObjectEvent>().Publish(this.Member);
        }
    }
}
