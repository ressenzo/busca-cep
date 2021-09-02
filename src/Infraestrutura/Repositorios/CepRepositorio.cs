using AutoMapper;
using Dominio.Entidades;
using Dominio.Repositorios;
using Infraestrutura.Resultados;
using System.Threading.Tasks;

namespace Infraestrutura.Repositorios
{
    public class CepRepositorio : RestBaseRepositorio, ICepRepositorio
    {
        private readonly IMapper _mapper;

        public CepRepositorio(IMapper mapper)
            : base("https://viacep.com.br/")
        {
            _mapper = mapper;
        }

        public async Task<Cep> ObterCep(string cep)
        {
            var resultado = await GetAsync<CepResultado>($"ws/{cep}/json/");

            return _mapper.Map<CepResultado, Cep>(resultado);
        }
    }
}
