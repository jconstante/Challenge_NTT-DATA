using AutoMapper;
using Servicios.Api.Entity;
using Servicios.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Api.Mapper
{
    class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PersonaModel, Persona>().ReverseMap();
            CreateMap<CuentaModel, Cuenta>().ReverseMap();
            CreateMap<ClienteModel, Cliente>().ReverseMap();
            CreateMap<MovimientoModel, Movimiento>().ReverseMap();
        }
    }

}
