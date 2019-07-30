using BenchmarkDotNet.Running;
using Matricula.Controle;
using System;

namespace Matricula.Apresentacao
{
    internal static class Program
    {
        public static readonly string DiretorioPadrao = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        private static void Main()
        {
            var msgError = string.Empty;
            MatriculaControle _MatriculaControle = new MatriculaControle();

            while (true)
            {
                Console.WriteLine("1 - Gerar aquivo com matriculas verificadas.");
                Console.WriteLine("2 - Gerar arquivo de matriculas com digito verificados.");
                Console.WriteLine("O que deseja verificar?");
                var escolha = Console.ReadLine();

                switch (escolha)
                {
                    case "1":
                        _MatriculaControle.VerificarMatriculas(out msgError);

                        if (!string.IsNullOrEmpty(msgError))
                        {
                            Console.WriteLine(msgError);
                        }

                        SelecaoMenus();
                        break;
                    case "2":
                        _MatriculaControle.GerarDigitoVerificador(out msgError);

                        if (!string.IsNullOrEmpty(msgError))
                        {
                            Console.WriteLine(msgError);
                        }

                        SelecaoMenus();
                        break;
                    default:
                        continue;
                }
                break;
            }
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
