using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ClassLibraryExemplo
{
    public class ClasseA
    {
        private string GetParameterDirection(string direcao)
        {
            if (direcao.ToUpper().CompareTo("OUT") == 0)
            {
                return "";
            }
            if (direcao.ToUpper().CompareTo("IN") == 0)
            {
                return "";
            }
            if (direcao.ToUpper().CompareTo("RETURN") == 0)
            {
                return "";
            }
            if (direcao.ToUpper().CompareTo("IN/OUT") == 0)
            {
                return "";
            }

            // TODO: É para capturar Throws fora dos blocos Try/Catch/Finally?
            throw new ArgumentException(string.Format("A direção informada não possui equivalente em ParameterDirection: {0}", direcao));
        }


        public void MetodoComTryCatchGenerico()
        {
            // O código existente depois de um throw não é analisado
            // throw new Exception();

            try
            {
                MetodoCall();
                MetodoCall();
                //throw new Exception();
            }
            catch (ArgumentException)
            {
                throw new Exception();
            }
            catch (IOException)
            {
                throw new Exception();
            }
            catch (OutOfMemoryException)
            {
                throw new Exception();
            }
            finally
            {
                throw new Exception();
            }
        }

        public ClasseA()
        {

        }

        public ClasseA(int i = 0)
        {

        }

        public void MetodoCall()
        {
        }

        public void MetodoComTryCatchEspecializado()
        {
            try
            {
                return;
            }
            catch (ArithmeticException)
            {
                throw;
            }

        }
        public void MetodoComTryCatchGenericoCatchEspecializado()
        {
            try
            {
                return;
            }
            catch (ArgumentOutOfRangeException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public void MetodoComTryCatchGenericoTryCatchEspecializado()
        {
            try
            {
                return;
            }
            catch (Exception)
            {
                throw;
            }


            try
            {
                return;
            }
            catch (ArgumentException)
            {
                throw;
            }


        }
        public void MetodoComTryCatchGenericoFinally()
        {
            try
            {
                return;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }

        }
        public void MetodoChamandoMetodoComTryCatchGenerico()
        {
            MetodoComTryCatchGenerico();
        }
        public void MetodoComTryLancandoThrowGenerico()
        {
            try
            {
                throw new Exception();
            }
            finally
            {

            }
        }
        public void MetodoComTryLancandoThrowEspecializado()
        {
            try
            {
                throw new InvalidOperationException();
            }
            finally
            {

            }
        }
        public void MetodoComTryLancandoMaisDeUmThrow()
        {
            try
            {
                if (true) //TODO: Verificar se o compilador entende ser possível mais de um Statement Throw
                    throw new ApplicationException();
                else
                    throw new AggregateException();
            }
            finally
            {

            }
        }
        public void MetodoComFinallyLancandoThrowGenerico()
        {
            try
            {

            }
            finally
            {
                throw new Exception();
            }
        }
        public void MetodoComFinallyLancandoThrowEspecializado()
        {
            try
            {

            }
            finally
            {
                throw new IOException();
            }
        }
        public void MetodoDaInterface()
        {

        }
        public void MetodoComplexo()
        {
            try
            {
                MetodoDaInterface();
                MetodoDaInterface();
                MetodoDaInterface();
                //throw new MyException();
            }
            catch (FileNotFoundException)
            {
                MetodoDaInterface();
                throw new MyException();
            }
            catch (IOException)
            {
                MetodoDaInterface();
                throw new MyException();
            }
            catch (Exception)
            {
                MetodoDaInterface();
                throw new OutOfMemoryException();
            }
            finally
            {

            }

        }
    }
}