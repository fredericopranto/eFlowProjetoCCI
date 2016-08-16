using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ClassLibraryExemplo
{
    public class ClasseInterface : IClasse
    {
        public void MetodoDaInterface()
        {
            try
            {
                throw new NotImplementedException();
            }
            catch
            {
            }
        }
    }
}