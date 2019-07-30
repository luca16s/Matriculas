using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Matricula.Modelo
{
    [MemoryDiagnoser]
    public class MatriculaModelo
    {
        //[Benchmark]
        //[ArgumentsSource(nameof(MatriculaParaGerar))]
        public List<string> GerarDigitoVerificador(List<string> matriculas)
        {
            if (matriculas == null)
                throw new ArgumentNullException("Lista de matrículas não pode ser nula.");

            if (matriculas.Count <= 0)
                throw new ArgumentOutOfRangeException("Lista de matrículas deve ser maior que zero.");

            List<string> resultado = new List<string>();
            var entidadeMatricula = new Entidades.Matricula();

            foreach (var matricula in matriculas)
            {
                matricula.Trim();

                if (matricula == null
                    || matricula.Equals(string.Empty)
                    || matricula.Length < 0
                    || matricula.Length < 4
                    || matricula.Length > 6) continue;

                entidadeMatricula.GerarDigitoVerificador(matricula);

                resultado.Add(entidadeMatricula.ToString());
            }
            return resultado;
        }

        ///[Benchmark]
        ///[ArgumentsSource(nameof(MatriculaParaVerificar))]
        public List<string> VerificarMatriculas(List<string> matriculas)
        {
            if (matriculas == null
                || matriculas.Count <= 0)
            {
                return null;
            }

            List<string> resultado = new List<string>();
            var entidadeMatricula = new Entidades.Matricula();

            foreach (var matricula in GerarDigitoVerificador(matriculas))
            {
                if (matricula == null || matricula.Equals("")) continue;

                if (matriculas.Contains(matricula))
                {
                    resultado.Add($"{matricula} verdadeiro");
                }
                else
                {
                    resultado.Add($"{matricula} falsa");
                }
            }
            return resultado;
        }

        public IEnumerable<List<string>> MatriculaParaGerar()
        {
            var list = new List<string>();
            Random numero = new Random();

            for (int i = 0; i < 1000000; i++)
            {
                list.Add(numero.Next(9999).ToString());
            }

            yield return list;
            //yield return new List<string>()
            //{
            //    "1653",
            //    "2432",
            //    "3564",
            //    "3617",
            //    "3927",
            //    "5033",
            //    "7097",
            //    "8443",
            //    "9355",
            //    "9737"
            //};
        }

        public IEnumerable<List<string>> MatriculaParaVerificar()
        {
            yield return new List<string>()
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
        }
    }
}
