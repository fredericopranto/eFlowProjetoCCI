using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ClassLibraryExemplo
{
    public class ClasseInterface2 : IClasse
    {
        public void MetodoDaInterface()
        {
            try
            {
                throw new NotImplementedException();
            }
            catch
            {
                throw new NotImplementedException();
            }
            finally
            {
                throw new NotImplementedException();
            }
        }
    }
}