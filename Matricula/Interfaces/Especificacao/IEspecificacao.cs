namespace Matricula.Interfaces.Especificacao
{
    public interface IEspecificacao<in TEntity> where TEntity : class
    {
        bool ESatisfeito(TEntity entity);
    }
}
