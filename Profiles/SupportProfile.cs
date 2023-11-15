using Api.Entities;
using Api.Models;
using AutoMapper;

namespace Api.Profiles
{
    public class SupportProfile : Profile
    {
        public SupportProfile()
        {
            CreateMap<Support, SupportDTO>();
        }
    }
}
