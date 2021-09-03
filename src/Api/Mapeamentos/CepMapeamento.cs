using AutoMapper;
using Api.Models;
using Dominio.Entidades;

namespace Api.Mapeamento
{
    public class CepMapeamento : Profile
    {
        public CepMapeamento()
        {
            CreateMap<Cep, RetornoCepModel>()
                .ForMember(dest => dest.Cep, map => map.MapFrom(x => x.Numero));
        }
    }
}
