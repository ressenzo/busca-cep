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
                .ForMember(dest => dest.Numero, map => map.MapFrom(x => x.Cep));
        }
    }
}
