using AutoMapper;
using BuscaCep.Models;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuscaCep.Mapeamento
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
