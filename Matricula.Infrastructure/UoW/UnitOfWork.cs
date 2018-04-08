using Matricula.Infrastructure.Repository;
using Matricula.Interfaces.Repository;

namespace Matricula.Infrastructure.UoW
{
    public class UnitOfWork
    {
        private readonly string _path;

        public UnitOfWork()
        {
            
        }
        public UnitOfWork(string path)
        {
            _path = path;
        }
        // = $@"C:\Users\lucag\Desktop\matriculasParaVerificar.txt";
        private IMatriculaRepository _matriculaRepository;

        public IMatriculaRepository MatriculaRepository =>
            _matriculaRepository ?? (_matriculaRepository = new MatriculaRepository(_path));
    }
}
