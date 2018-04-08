using Matricula.Interfaces.Especificacao;
using Matricula.Entities;

namespace Matricula.Especificacao
{
    public class Validacoes : IEspecificacao<Entities.Matricula>
    {
        public /* static */ bool StringLenght(string propriedade, int minlenght, int maxLenght)
        {
            return propriedade.Length <= minlenght || propriedade.Length >= maxLenght;
        }

        public bool ESatisfeito(Entities.Matricula entity)
        {
            throw new System.NotImplementedException();
        }

        public static bool IsValid(string dv, string matricula) => matricula.Contains(dv);
    }
}
