using AutoMapper;
using KlinikAPI.DTOS;
using KlinikAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KlinikAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //CreateMap<Profinsi, ProfinsiDTO>();
            CreateMap<Profinsi, ProfinsiDTO>().ReverseMap();
            //CreateMap<ProfinsiDTO, Profinsi>(); bisa reverse seperti ini juga
        }
    }
}
