using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Matricula.Tests
{
    [TestClass]
    public class MatriculaTests
    {
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void MatriculaObrigatoria()
        {
            var unused = new Entities.Matricula(null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MatriculaMaior()
        {
            var unused = new Entities.Matricula("1111111");
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MatriculaMenor()
        {
            var unused = new Entities.Matricula("111");
        }
    }
}
