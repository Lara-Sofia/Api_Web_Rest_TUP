using AutoMapper;
using Api.Models.Responses;

namespace Api.Profiles
{
    public class ResponseProfile : Profile
    {
        public ResponseProfile()
        {
            CreateMap<ResponseForCreationDto, Entities.Response>();
            CreateMap<Entities.Response, ResponseDTO>();
        }
    }
}
