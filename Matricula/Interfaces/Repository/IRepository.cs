namespace Matricula.Interfaces.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Salvar(TEntity objEntity);
        string ListarObj();
    }
}
