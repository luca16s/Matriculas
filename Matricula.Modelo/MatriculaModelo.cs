using System.Collections.Generic;

namespace Matricula.Modelo
{
    public class MatriculaModelo
    {
        public List<string> GerarDigitoVerificador(List<string> matriculas)
        {
            if(matriculas == null
                || matriculas.Count <= 0)
            {
                return null;
            }

            List<string> resultado = new List<string>();
            var entidadeMatricula = new Entidades.Matricula();

            foreach (var matricula in matriculas)
            {
                matricula.Trim();

                if (matricula == null 
                    || matricula.Equals(string.Empty)
                    || matricula.Length < 0 
                    || matricula.Length < 4
                    || matricula.Length > 6) continue;

                entidadeMatricula.Codigo = matricula;

                entidadeMatricula.GerarDigitoVerificador(entidadeMatricula.Codigo);

                resultado.Add(entidadeMatricula.ToString());
            }
            return resultado;
        }

        public List<string> VerificarMatriculas(List<string> matriculas)
        {
            if (matriculas == null
                || matriculas.Count <= 0)
            {
                return null;
            }

            List<string> resultado = new List<string>();
            var entidadeMatricula = new Entidades.Matricula();

            foreach (var matricula in GerarDigitoVerificador(matriculas))
            {
                if (matricula == null || matricula.Equals("")) continue;

                if (matriculas.Contains(matricula))
                {
                    resultado.Add($"{matricula} verdadeiro");
                }
                else
                {
                    resultado.Add($"{matricula} falsa");
                }
            }

            return resultado;
        }
    }
}
