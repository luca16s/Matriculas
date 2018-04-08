using System;
using System.Linq;
using Matricula.Validacoes;

namespace Matricula.Entities
{
    public class Matricula
    {
        private string _codigo;
        public string Dv { get; set; }
        private const int MaxLenght = 5;
        private const int MinLenght = 4;

        public string Codigo
        {
            get => _codigo;
            set
            {
                if (value == null)
                    throw new ArgumentNullException();
                if (ValidacaoMatricula.StringLenght(value, MinLenght, MaxLenght))
                    throw new ArgumentOutOfRangeException();
                _codigo = value;
            }
        }

        public void GerarDigitoVerificador(string codigo)
        {
            if (string.IsNullOrEmpty(codigo))
            {
                throw new ArgumentNullException();
            }

            if (string.IsNullOrWhiteSpace(codigo))
            {
                throw new Exception();
            }
            var total = codigo.Select((t, i) => Convert.ToInt32(codigo.Substring(i, 1))).Select((numero, i) => numero * (5 - i)).Sum();
            Dv = (total % 16).ToString("X");
        }
    }
}
