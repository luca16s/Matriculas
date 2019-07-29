using Matricula.Entidades.Interfaces.Repository;

namespace Matricula.Infra.Repository
{
    public class MatriculaRepository : Repository, IMatriculaRepository
    {
        public MatriculaRepository(string caminhoInicial, string caminhoFinal) : base(caminhoInicial, caminhoFinal)
        {

        }
    }
}
