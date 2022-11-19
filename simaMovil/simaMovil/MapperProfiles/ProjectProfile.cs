using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using simaMovil.Models;
using simaMovil.Dtos;

namespace simaMovil.MapperProfiles
{
    internal class ProjectProfile :Profile
    {
        public ProjectProfile()
        {
            CreateMap<UserModel, UserDto>();

            CreateMap<RepVtaMesDto, RepVtaMesModel>()
                .ForMember(dest => dest.VentaAP, act => act.MapFrom(src => src.venta2013))
                .ForMember(dest => dest.VentaAct, act => act.MapFrom(src => src.venta2014));
        }

    }
}
