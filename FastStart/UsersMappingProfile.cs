using AutoMapper;
using FastStart.Entities;
using FastStart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastStart
{
    public class UsersMappingProfile : Profile
    {
        public UsersMappingProfile()
        {
            CreateMap<Users, UsersDTO>();

            CreateMap<Roles, RolesDTO>();

            CreateMap<CreateUsersDTO, Users>()
                .ForMember(u => u.Roles,
                c => c.MapFrom(dto => new Roles()
                { Nazwa = dto.Nazwa, nrFBO = dto.nrFBO }));
        }
    }
}
