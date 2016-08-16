using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ClassLibraryExemplo
{
    public class ClasseTests
    {
        public void MetodoTests()
        {
            try
            {
                MetodoCall();
                Console.Read();
                MetodoCall();
                throw new Exception("Exception");
            }
            catch
            {
                MetodoCall();
                throw new Exception("Exception");
            }
        }

        public void MetodoCall()
        {
        }

        private static int RetornaModuloOnze(string pNumero)
        {
            int soma = 0;
            int peso = 2;
            for (int i = pNumero.Length; i > 0; i--)
            {
                // Reseta o peso
                if (peso == 10)
                    peso = 2;
                soma += int.Parse(pNumero[i - 1].ToString()) * peso;
                peso += 1;
            }
            return soma % 11;
        }
    }
}