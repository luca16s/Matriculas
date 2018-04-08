namespace Matricula.Validacoes
{
    public class ValidacaoMatricula
    {
        public static bool StringLenght(string propriedade, int minlenght, int maxLenght)
        {
            return propriedade.Length <= minlenght || propriedade.Length >= maxLenght;
        }
    }
}
