using System.Collections.ObjectModel;
using Matricula.Interfaces.Repository;

namespace Matricula.Infrastructure.Repository
{
    public class MatriculaRepository : Repository, IMatriculaRepository
    {
        public MatriculaRepository(string caminhoInicial, string caminhoFinal) : base(caminhoInicial, caminhoFinal)
        {

        }
    }
}
