using System.Collections.ObjectModel;
using Matricula.Interfaces.Repository;

namespace Matricula.Infrastructure.Repository
{
    public class MatriculaRepository : Repository, IMatriculaRepository
    {
        public MatriculaRepository(string path) : base(path)
        {

        }
    }
}
