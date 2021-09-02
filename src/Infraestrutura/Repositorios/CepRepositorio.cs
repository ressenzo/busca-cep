using Dominio.Entidades;
using Dominio.Repositorios;
using System.Threading.Tasks;

namespace Infraestrutura.Repositorios
{
    public class CepRepositorio : ICepRepositorio
    {
        public Task<Cep> ObterCep(string cep)
        {
            throw new System.NotImplementedException();
        }
    }
}
