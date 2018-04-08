namespace Matricula.Interfaces.Especificacao
{
    public interface IEspecificacao<in TEntity> where TEntity : class
    {
        bool StringLenght(string propriedade, int minlenght, int maxLenght);
        bool ESatisfeito(TEntity entity);
    }
}
