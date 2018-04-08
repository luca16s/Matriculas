using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matricula.Interfaces.Repository;

namespace Matricula.Infrastructure.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly string Path;

        public Repository(string path)
        {
            Path = path;
        }

        public void Salvar(TEntity objEntity)
        {
            using (var escrita = new StreamWriter(Path))
            {
                escrita.Write(objEntity);
            }
        }

        public string ListarObj()
        {
            using (var leitura = new StreamReader(Path))
            {
                return leitura.ReadLine();
            }
        }
    }
}
