using System.Collections.Generic;
using System.IO;

namespace Matricula.Infra.Repository
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

        public void Salvar(List<string> obj)
        {
            using (var escrita = new StreamWriter(CaminhoFinal))
            {
                foreach (var objList in obj)
                {
                    escrita.WriteLine(objList);
                }
            }
        }

        public List<string> ListarObj()
        {
            using (var leitura = new StreamReader(CaminhoInicial))
            {
                List<string> listaMatriculas = new List<string>();
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
