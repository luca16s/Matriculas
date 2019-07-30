using System;
using System.Linq;
using Matricula.Entidades.Validacoes;

namespace Matricula.Entidades
{
    public class Matricula
    {
        private string _Matricula;
        private string _DigitoVerificador { get; set; }
        private const int MaxLenght = 4;
        private const int MinLenght = 4;

        public string Codigo
        {
            get => _Matricula;
            set => _Matricula = value.Substring(0, MinLenght);
        }

        public void GerarDigitoVerificador(string codigo)
        {
            if (string.IsNullOrEmpty(codigo)
                || string.IsNullOrWhiteSpace(codigo))
                throw new ArgumentNullException();

            if (!codigo.All(char.IsDigit))
                throw new InvalidCastException();

            if (ValidacaoMatricula.StringLenght(codigo, MinLenght, MaxLenght))
                throw new ArgumentOutOfRangeException();

            Codigo = codigo;

            var total = codigo.Select((t, i) => Convert.ToInt32(codigo.Substring(i, 1))).Select((numero, i) => numero * (5 - i)).Sum();
            _DigitoVerificador = (total % 16).ToString("X");
        }

        public override string ToString()
        {
            return $"{Codigo}-{_DigitoVerificador}";
        }
    }
}
