using Matricula.Modelo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Matricula.Tests
{
    [TestClass]
    public class MatriculaModeloTests
    {
        public MatriculaModelo MatriculaModelo;
        public List<string> ListaComDigito;
        public List<string> ListaSemDigito;

        [TestInitialize]
        public void TestInitialize()
        {
            MatriculaModelo = new MatriculaModelo();

            ListaComDigito = new List<string>()
            {
                    "0154-C",
                    "0478-5",
                    "1343-3",
                    "5139-8",
                    "5979-4",
                    "6931-E",
                    "7604-3",
                    "7927-C",
                    "8657-E",
                    "8793-5"
            };

            ListaSemDigito = new List<string> ()
            {
                "1653",
                "2432",
                "3564",
                "3617",
                "3927",
                "5033",
                "7097",
                "8443",
                "9355",
                "9737"
            };
        }

        [TestMethod]
        public void GeraDigitoVerificadorComListaNula()
        {
            //Arrange + Act + Assert
            Assert.ThrowsException<ArgumentNullException>(() => MatriculaModelo.GerarDigitoVerificador(null));
        }

        [TestMethod]
        public void GeraDigitoVerificadorComListaVazia()
        {
            //Arrange + Act + Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => MatriculaModelo.GerarDigitoVerificador(new List<string>()));
        }

        [TestMethod]
        public void GeraDigitoVerificadorComListaQueContemNumerosNaRaiz()
        {
            //Arrange
            ListaSemDigito.Add("B123");

            //Arrange + Act + Assert
            Assert.ThrowsException<InvalidCastException>(() => MatriculaModelo.GerarDigitoVerificador(ListaSemDigito));
        }
    }
}
