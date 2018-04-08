using System.Collections.Generic;

namespace Matricula.Interfaces.Repository
{
    public interface IRepository
    {
        void Salvar(ICollection<string> obj);
        ICollection<string> ListarObj();
    }
}
