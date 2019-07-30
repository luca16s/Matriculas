using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Matricula.Tests
{
    [TestClass]
    public class MatriculaEntidadeTests
    {
        Entidades.Matricula matricula;

        [TestInitialize]
        public void TestInitialize()
        {
            //Arrange
            matricula = new Entidades.Matricula();
        }

        [TestMethod]
        public void GerarDigitoVerificadorDeValorBranco()
        {
            //Act + Assert
            Assert.ThrowsException<ArgumentNullException>(() => matricula.GerarDigitoVerificador(""));
        }

        [TestMethod]
        public void GerarDigitoVerificadorDeValorNulo()
        {
            //Act + Assert
            Assert.ThrowsException<ArgumentNullException>(() => matricula.GerarDigitoVerificador(null));
        }

        [TestMethod]
        public void GerarDigitoVerificadorDeValorMaiorQuePermitido()
        {
            //Act + Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => matricula.GerarDigitoVerificador("15715"));
        }

        [TestMethod]
        public void GerarDigitoVerificadorDeValorMenorQuePermitido()
        {
            //Act + Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => matricula.GerarDigitoVerificador("111"));
        }

        [TestMethod]
        public void ValidarDigitoVerificadorGerado()
        {
            //Arrange
            var valoresperado = "9876-E";
            matricula.Codigo = "9876";

            //Assert
            matricula.GerarDigitoVerificador(matricula.Codigo);

            Assert.AreEqual(valoresperado, matricula.ToString());
        }

        [TestMethod]
        public void InsereNumeroMatriculaComBaseSemNumeral()
        {
            //Act + Assert
            Assert.ThrowsException<InvalidCastException>(() => matricula.GerarDigitoVerificador("ABCD"));
        }

        [TestMethod]
        public void InsereNumeroMatriculaComBaseMista()
        {
            //Act + Assert
            Assert.ThrowsException<InvalidCastException>(() => matricula.GerarDigitoVerificador("4B1D"));
        }

        [TestMethod]
        public void InsereNumeroMatriculaComBaseNormal()
        {
            //Act + Assert
            Assert.ThrowsException<InvalidCastException>(() => matricula.GerarDigitoVerificador("9876-E"));
        }
    }
}
