using Dominio.Entidades;
using System.Threading.Tasks;

namespace Servicos.Contratos
{
    public interface IObterCepServico
    {
        Task<Cep> ObterCep(string cep);
    }
}
