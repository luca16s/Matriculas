namespace Matricula.Entidades.Validacoes
{
    public class ValidacaoMatricula
    {
        public static bool StringMinLenght(string propriedade, int minlenght)
        {
            return propriedade.Length < minlenght;
        }

        public static bool StringMaxLenght(string propriedade, int maxLenght)
        {
            return propriedade.Length > maxLenght;
        }

        public static bool StringLenght(string propriedade, int minLenght, int maxLenght)
        {
            return StringMinLenght(propriedade, minLenght) || StringMaxLenght(propriedade, maxLenght);
        }
    }
}
