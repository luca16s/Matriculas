using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matricula.Interfaces.Repository;

namespace Matricula.Infrastructure.Repository
{
    public class MatriculaRepository : Repository<Entities.Matricula>, IMatriculaRepository
    {
        public MatriculaRepository(string path) : base(path)
        {

        }
    }
}
