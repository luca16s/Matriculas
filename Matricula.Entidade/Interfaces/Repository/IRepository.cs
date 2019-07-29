using System.Collections.Generic;

namespace Matricula.Entidades.Interfaces.Repository
{
    public interface IRepository
    {
        void Salvar(List<string> obj);
        List<string> ListarObj();
    }
}
