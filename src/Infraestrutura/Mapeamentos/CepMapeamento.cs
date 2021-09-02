using AutoMapper;
using Dominio.Entidades;
using Infraestrutura.Resultados;

namespace Infraestrutura.Mapeamentos
{
    public class CepMapeamento : Profile
    {
        public CepMapeamento()
        {
            CreateMap<CepResultado, Cep>()
                .ConstructUsing(src => new Cep(src.Cep));
        }
    }
}
