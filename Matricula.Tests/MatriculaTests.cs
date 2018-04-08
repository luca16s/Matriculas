using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Matricula = Matricula.Entities.Matricula;

namespace Matricula.Tests
{
    [TestClass]
    public class MatriculaTests
    {
        public Entities.Matricula Matricula { get; set; }
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void MatriculaObrigatoria()
        {
            var unused = new Entities.Matricula {Codigo = null};
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MatriculaMaior()
        {
            var unused = new Entities.Matricula { Codigo = "1111111" };
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MatriculaMenor()
        {
            var unused = new Entities.Matricula {Codigo = "111"};
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void ChecarDigitoVerificadorNull()
        {
            Matricula = new Entities.Matricula();
            Matricula.GerarDigitoVerificador(null);
        }

        [TestMethod, ExpectedException(typeof(Exception))]
        public void ChecarDigitoVerificadorEspacoBranco()
        {
            Matricula.GerarDigitoVerificador(" ");
        }

        [TestMethod]
        public void GetCodigo()
        {
            Matricula = new Entities.Matricula { Codigo = "0478-5" };
            Assert.AreSame("0478-5", Matricula.Codigo);
        }
    }
}
