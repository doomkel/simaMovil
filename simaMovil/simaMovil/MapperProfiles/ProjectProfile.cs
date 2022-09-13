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
        }

    }
}
