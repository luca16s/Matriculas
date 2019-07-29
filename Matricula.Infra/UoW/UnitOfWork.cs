using Matricula.Entidades.Interfaces.Repository;
using Matricula.Infra.Repository;

namespace Matricula.Infra.UoW
{
    public class UnitOfWork
    {
        private readonly string _caminhoInicial;
        private readonly string _caminhoFinal;

        public UnitOfWork(string caminhoInicial, string caminhoFinal)
        {
            _caminhoInicial = caminhoInicial;
            _caminhoFinal = caminhoFinal;
        }

        private IMatriculaRepository _matriculaRepository;

        public IMatriculaRepository MatriculaRepository =>
            _matriculaRepository ?? (_matriculaRepository = new MatriculaRepository(_caminhoInicial, _caminhoFinal));
    }
}
