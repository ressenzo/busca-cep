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

        public async Task<Cep> ObterCep(string numeroCep)
        {
            var cep = new Cep(numeroCep);
            ValidarCep(cep);

            var cepEncontrado = await _cepRepositorio.ObterCep(cep.Numero);

            if (!cepEncontrado.Valido)
            {
                throw new InvalidOperationException();
            }

            return cepEncontrado;
        }

        private void ValidarCep(Cep cep)
        {
            if (!cep.Valido)
            {
                throw new ArgumentException(cep.Mensagem);
            }
        }
    }
}
