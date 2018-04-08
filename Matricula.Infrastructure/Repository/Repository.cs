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
                foreach (var objList in obj)
                {
                    escrita.Write(objList);
                }
            }
        }

        public ICollection<string> ListarObj()
        {
            using (var leitura = new StreamReader(CaminhoInicial))
            {
                ICollection<string> listaMatriculas = new List<string>();
                string line;
                while ((line = leitura.ReadLine()) != null)
                {
                    listaMatriculas.Add(line);
                }
                return listaMatriculas;
            }
        }
    }
}
