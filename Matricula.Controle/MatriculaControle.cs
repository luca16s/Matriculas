using Matricula.Constants;
using Matricula.Infra.UoW;
using Matricula.Modelo;
using System;
using System.Collections.Generic;

namespace Matricula.Controle
{
    public class MatriculaControle
    {
        public readonly string _diretorioPadrao;
        public readonly string _caminhoInicial = FileNames.MatriculasParaVerificar;
        public readonly string _caminhoFinal = FileNames.MatriculasVerificadas;
        private readonly UnitOfWork _UnitOfWork;

        public MatriculaControle()
        {
            _diretorioPadrao = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            _caminhoInicial = _diretorioPadrao + _caminhoInicial;
            _caminhoFinal = _diretorioPadrao + _caminhoFinal;
            _UnitOfWork = new UnitOfWork(_caminhoInicial, _caminhoFinal);
        }

        public List<string> LerArquivo(out string msgError)
        {
            msgError = string.Empty;

            try
            {
                return _UnitOfWork.MatriculaRepository.ListarObj();
            }
            catch (Exception e)
            {
                msgError = $"Arquivo não pode ser lido corretamente. Exception code: {e}";
                return null;
            }
        }

        public void GerarDigitoVerificador(out string msgError)
        {
            var matriculaModelo = new MatriculaModelo();

            var arquivo = LerArquivo(out msgError);

            var matriculasComDv = matriculaModelo.GerarDigitoVerificador(arquivo);

            _UnitOfWork.MatriculaRepository.Salvar(matriculasComDv);
        }

        public void VerificarMatriculas(out string msgError)
        {
            msgError = string.Empty;

            var matriculaModelo = new MatriculaModelo();

            var arquivo = LerArquivo(out msgError);

            var matriculasComDv = matriculaModelo.GerarDigitoVerificador(arquivo);

            var matriculasVerificadas = matriculaModelo.VerificarMatriculas(matriculasComDv);

            _UnitOfWork.MatriculaRepository.Salvar(matriculasVerificadas);
        }
    }
}
