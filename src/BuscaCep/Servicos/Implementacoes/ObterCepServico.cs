using BuscaCep.Entidades;
using BuscaCep.Servicos.Interfaces;
using System.Threading.Tasks;

namespace BuscaCep.Servicos.Implementacoes
{
    public class ObterCepServico : IObterCepServico
    {
        public Task<Cep> ObterCep(string cep)
        {
            throw new System.NotImplementedException();
        }
    }
}
