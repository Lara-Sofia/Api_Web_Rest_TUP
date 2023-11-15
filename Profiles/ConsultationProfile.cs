using Api.Entities;
using Api.Models.Consults;
using AutoMapper;

namespace Api.Profiles
{
    public class ConsultationProfile : Profile
    {
        public ConsultationProfile()
        {
            CreateMap<ConsultationForCreationDto, Consultation>();
            CreateMap<Consultation, ConsultationDTO>();
        }
    }
}
