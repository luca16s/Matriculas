using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Matricula.Constants;
using Matricula.Infrastructure.UoW;

namespace Matricula.Apresentacao
{
    internal class Program
    {
        private static void Main()
        {
            var stringBuilder = new StringBuilder();

            while (true)
            {
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                //Uow = new UnitOfWork("");

                //IEnumerable matriculas = Uow.MatriculaRepository.ListarObj();
                Console.WriteLine("1 - Gerar aquivo com matriculas verificadas.");
                Console.WriteLine("2 - Gerar arquivo de matriculas com digito verificados.");
                Console.WriteLine("O que deseja verificar?");
                var escolha = Console.ReadLine();
                switch (escolha)
                {
                    case "1":
                        VerificarMatriculas(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), stringBuilder);
                        break;
                    case "2":
                        GerarDigitoVerificador(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), stringBuilder);
                        break;
                    default:
                        continue;
                }

                break;
            }
        }

        public static void VerificarMatriculas(string basePath, StringBuilder stringBuilder)
        {
            stringBuilder.Append(basePath).Append(FileNames.MatriculasParaVerificar);
            var uow = new UnitOfWork(stringBuilder.ToString());
            stringBuilder.Clear();

            IEnumerable matriculas = uow.MatriculaRepository.ListarObj();
            var mat = new Entities.Matricula();
            ICollection<string> resultado = new List<string>();

            foreach (var matricula in matriculas)
            {
                if (matricula == null || matricula.Equals("")) continue;
                mat.GerarDigitoVerificador(matricula.ToString().Substring(0, 4));

                if (matricula.ToString().Substring(5, 1).Equals(mat.Dv))
                {
                    stringBuilder.Append(matricula).Append(" ").Append("verdadeiro").AppendLine();
                    resultado.Add(stringBuilder.ToString());
                }
                else
                {
                    stringBuilder.Append(matricula).Append(" ").Append("falso").AppendLine();
                    resultado.Add(stringBuilder.ToString());
                }
                uow.MatriculaRepository.Salvar(resultado);

                stringBuilder.Clear();
            }
        }

        public static void GerarDigitoVerificador(string basePath, StringBuilder stringBuilder)
        {
            stringBuilder.Append(basePath).Append(FileNames.MatriculasParaVerificar);
        }
    }
}
