using System;
using System.Collections.Generic;
using System.IO;

namespace Matricula.Infrastructure.Repository
{
    public class Repository
    {
        protected readonly string CaminhoInicial;
        protected readonly string CaminhoFinal;

        public Repository(string caminhoInicial, string caminhoFinal)
        {
            CaminhoInicial = caminhoInicial;
            CaminhoFinal = caminhoFinal;
        }

        public void Salvar(ICollection<string> obj)
        {
            using (var escrita = new StreamWriter(CaminhoFinal))
            {
                try
                {
                    foreach (var objList in obj)
                    {
                        escrita.Write(objList);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"A lista de matrículas não pode ser salva corretamente. Exception code: {e}");
                    throw;
                }
            }
        }

        public ICollection<string> ListarObj()
        {
            using (var leitura = new StreamReader(CaminhoInicial))
            {
                ICollection<string> listaMatriculas = new List<string>();
                try
                {
                    string line;
                    while ((line = leitura.ReadLine()) != null)
                    {
                        listaMatriculas.Add(line);
                    }
                    return listaMatriculas;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Arquivo não pode ser lido corretamente. Exception code: {e}");
                    throw;
                }
            }
        }
    }
}
