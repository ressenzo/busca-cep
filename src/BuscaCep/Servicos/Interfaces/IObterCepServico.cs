using BuscaCep.Entidades;
using System.Threading.Tasks;

namespace BuscaCep.Servicos.Interfaces
{
    public interface IObterCepServico
    {
        Task<Cep> ObterCep(string cep);
    }
}
