using Matricula.Infrastructure.Repository;
using Matricula.Interfaces.Repository;

namespace Matricula.Infrastructure.UoW
{
    public class UnitOfWork
    {
        private readonly string _caminhoInicial;
        private readonly string _caminhoFinal;

        public UnitOfWork()
        {
            
        }
        public UnitOfWork(string caminhoInicial, string caminhoFinal)
        {
            _caminhoInicial = caminhoInicial;
            _caminhoFinal = caminhoFinal;
        }
        // = $@"C:\Users\lucag\Desktop\matriculasParaVerificar.txt";
        private IMatriculaRepository _matriculaRepository;

        public IMatriculaRepository MatriculaRepository =>
            _matriculaRepository ?? (_matriculaRepository = new MatriculaRepository(_caminhoInicial, _caminhoFinal));
    }
}
