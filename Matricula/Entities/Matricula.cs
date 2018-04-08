using System;
using System.Linq;
using System.Text;
using Matricula.Especificacao;

namespace Matricula.Entities
{
    public class Matricula
    {
        private string _codigo;
        public string Dv { get; private set; }
        private const int MaxLenght = 5;
        private const int MinLenght = 4;

        public Matricula(string matricula)
        {
            Codigo = matricula;
        }

        public string Codigo
        {
            get => _codigo;
            set
            {
                if (value == null)
                    throw new ArgumentNullException($@"A matrícula não pode ser nula!");
                //if (Validacoes.StringLenght(value, MinLenght, MaxLenght))
                    //throw new ArgumentOutOfRangeException($@"Matricula maior que 5 caracteres.");
                _codigo = value;
            }
        }

        public void GerarDigitoVerificador(string codigo)
        {
            Dv = codigo.Select((t, i) => Convert.ToInt32(codigo.Substring(i))).Select((numero, i) => numero * (i + 1)).Sum().ToString("X");
        }


    }
}
