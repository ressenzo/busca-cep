using Dominio.Entidades;
using Dominio.Repositorios;
using Servicos.Contratos;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Servicos.Servicos
{
    public class ObterCepServico : IObterCepServico
    {
        private readonly ICepRepositorio _cepRepositorio;

        public ObterCepServico(ICepRepositorio cepRepositorio)
        {
            _cepRepositorio = cepRepositorio;
        }

        public async Task<Cep> ObterCep(string cep)
        {
            ValidarCep(cep);

            var cepEncontrado = await _cepRepositorio.ObterCep(cep);

            if (string.IsNullOrWhiteSpace(cepEncontrado.Numero))
            {
                throw new InvalidOperationException();
            }

            return cepEncontrado;
        }

        private void ValidarCep(string cep)
        {
            if (
                string.IsNullOrWhiteSpace(cep) ||
                cep.Any(x => !char.IsDigit(x)) ||
                cep.Length >= 9
            )
            {
                throw new ArgumentException("CEP inválido. Deve conter apenas números, ter, no máximo, 8 caracteres e não pode ter espaço.");
            }
        }
    }
}
