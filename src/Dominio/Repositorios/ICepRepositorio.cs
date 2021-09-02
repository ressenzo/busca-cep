using Dominio.Entidades;
using System.Threading.Tasks;

namespace Dominio.Repositorios
{
    public interface ICepRepositorio
    {
        Task<Cep> ObterCep(string cep);
    }
}
