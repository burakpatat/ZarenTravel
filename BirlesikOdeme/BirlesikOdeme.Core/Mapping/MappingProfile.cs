using AutoMapper;
using BirlesikOdeme.API.Dtos;
using BirlesikOdeme.Core.Entities.Dtos;
using BirlesikOdeme.Core.Entities.Mernis;
using BirlesikOdeme.Core.Entities.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirlesikOdeme.Core.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Citizen, CitizenRequestModel>()
                .ReverseMap();

            CreateMap<SalesModel, SalesRequestModel>()
               .ReverseMap();
        }
        
    }
}
