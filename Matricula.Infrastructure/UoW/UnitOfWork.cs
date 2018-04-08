using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matricula.Infrastructure.Repository;
using Matricula.Interfaces.Repository;

namespace Matricula.Infrastructure.UoW
{
    public class UnitOfWork
    {
        private readonly string _path = $@"C:\Users\lucag\Desktop\matriculasParaVerificar.txt
";
        private IRepository<Entities.Matricula> _matriculaRepository;

        public IRepository<Entities.Matricula> MatriculaRepository =>
            _matriculaRepository ?? (_matriculaRepository = new Repository<Entities.Matricula>(_path));
    }
}
