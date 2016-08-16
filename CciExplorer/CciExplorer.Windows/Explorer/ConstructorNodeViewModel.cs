using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Cci;

namespace TourreauGilles.CciExplorer.Windows.Explorer
{
    internal class ConstructorNodeViewModel : MethodNodeViewModel
    {
        internal ConstructorNodeViewModel(IMethodDefinition constructor)
            : base(constructor)
        {
        }
    }
}
