using System;
using System.Linq;
using Matricula.Especificacao;

namespace Matricula.Entities
{
    public class Matricula
    {
        private string _codigo;
        public string Dv { get; private set; }
        private const int MaxLenght = 5;
        private const int MinLenght = 4;

        public string Codigo
        {
            get => _codigo;
            set
            {
                if (value == null)
                    throw new ArgumentNullException();
                if (!Validacoes.StringLenght(value, MinLenght, MaxLenght))
                    throw new ArgumentOutOfRangeException();
                _codigo = value;
            }
        }

        public void GerarDigitoVerificador(string codigo)
        {
            var total = codigo.Select((t, i) => Convert.ToInt32(codigo.Substring(i, 1))).Select((numero, i) => numero * (5 - i)).Sum();
            Dv =  (total%16).ToString("X");
        }
            //=> Dv = codigo.Select((t, i) 
            //    => Convert.ToInt32(codigo.Substring(i, 1))).Select((numero, i) => numero * (5 - i))
            //    .Sum().ToString("X");
    }
}
