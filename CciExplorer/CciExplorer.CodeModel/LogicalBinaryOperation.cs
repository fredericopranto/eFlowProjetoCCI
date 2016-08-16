﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Cci;
using Microsoft.Cci.MutableCodeModel;

namespace TourreauGilles.CciExplorer.CodeModel
{
    public abstract class LogicalBinaryOperation : Expression, IBinaryOperation
    {
        public IExpression LeftOperand
        {
            get;
            set;
        }

        public IExpression RightOperand
        {
            get;
            set;
        }


        public bool ResultIsUnmodifiedLeftOperand
        {
            get { throw new NotImplementedException(); }
        }

        public new IEnumerable<ILocation> Locations
        {
            get { throw new NotImplementedException(); }
        }
    }
}
