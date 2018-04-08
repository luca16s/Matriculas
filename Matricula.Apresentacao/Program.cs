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
        public static readonly string DiretorioPadrao =  Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        private static void Main()
        {
            var stringBuilder = new StringBuilder();
            var caminhoInicial = new StringBuilder();
            var caminhoFinal = new StringBuilder();

            while (true)
            {
                Console.WriteLine("1 - Gerar aquivo com matriculas verificadas.");
                Console.WriteLine("2 - Gerar arquivo de matriculas com digito verificados.");
                Console.WriteLine("O que deseja verificar?");
                var escolha = Console.ReadLine();
                switch (escolha)
                {
                    case "1":
                        VerificarMatriculas(DiretorioPadrao, stringBuilder, caminhoInicial, caminhoFinal);
                        break;
                    case "2":
                        GerarDigitoVerificador(DiretorioPadrao, stringBuilder, caminhoInicial, caminhoFinal);
                        break;
                    default:
                        continue;
                }
                break;
            }
        }

        public static void VerificarMatriculas(string basePath, StringBuilder stringBuilder, StringBuilder caminhoInicial, StringBuilder caminhoFinal)
        {
            caminhoInicial.Append(basePath).Append(FileNames.MatriculasParaVerificar);
            caminhoFinal.Append(basePath).Append(FileNames.MatriculasVerificadas);
            var uow = new UnitOfWork(caminhoInicial.ToString(), caminhoFinal.ToString());

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

                SelecaoMenus();
            }
        }

        public static void GerarDigitoVerificador(string basePath, StringBuilder stringBuilder, StringBuilder caminhoInicial, StringBuilder caminhoFinal)
        {
            caminhoInicial.Append(basePath).Append(FileNames.MatriculasSemDv);
            caminhoFinal.Append(basePath).Append(FileNames.MatriculasComDv);
            var uow = new UnitOfWork(caminhoInicial.ToString(), caminhoFinal.ToString());

            IEnumerable matriculas = uow.MatriculaRepository.ListarObj();
            var mat = new Entities.Matricula();
            ICollection<string> resultado = new List<string>();

            foreach (var matricula in matriculas)
            {
                if (matricula == null || matricula.Equals("")) continue;
                mat.GerarDigitoVerificador(matricula.ToString().Substring(0, 4));

                stringBuilder.Append(matricula).Append("-").Append(mat.Dv).AppendLine();
                resultado.Add(stringBuilder.ToString());

                stringBuilder.Clear();
            }
            uow.MatriculaRepository.Salvar(resultado);

            SelecaoMenus();
        }

        public static void SelecaoMenus()
        {
            Console.WriteLine("Deseja voltar ao menu anterior?");
            Console.WriteLine("1 - Sim");
            Console.WriteLine("2 - Não");
            var escolha = Console.ReadLine();

            switch (escolha)
            {
                case "1":
                    Console.Clear();
                    Main();
                    break;
                case "2":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }
}
