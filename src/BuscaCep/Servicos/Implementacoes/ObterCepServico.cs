using BuscaCep.Entidades;
using BuscaCep.Servicos.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BuscaCep.Servicos.Implementacoes
{
    public class ObterCepServico : IObterCepServico
    {
        public Task<Cep> ObterCep(string cep)
        {
            ValidarCep(cep);

            throw new NotImplementedException();
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
