using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Matricula.Infrastructure.Repository
{
    public class Repository
    {
        protected readonly string Path;

        public Repository(string path)
        {
            Path = path;
        }

        public void Salvar(ICollection<string> obj)
        {
            var localPath = $@"C:\Users\lucag\Desktop\matriculasVerificadas.txt";
            using (var escrita = new StreamWriter(localPath))
            {
                foreach (var objList in obj)
                {
                    escrita.Write(objList);
                }
            }
        }

        public ICollection<string> ListarObj()
        {
            using (var leitura = new StreamReader(Path))
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
