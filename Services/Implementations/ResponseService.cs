using Api.Data.Interfaces;
using Api.Entities;
using Api.Models.Responses;
using Api.Services.Interfaces;
using AutoMapper;

namespace Api.Services.Implementations
{
    public class ResponseService : IResponseService
    {
        private readonly IMapper _mapper;
        private readonly IResponseRepository _responseRepository;
        private readonly IConsultationService _consultationService;

        public ResponseService(IMapper mapper, IResponseRepository responseRepository, IConsultationService consultationService)
        {
            this._mapper = mapper;
            this._responseRepository = responseRepository;
            this._consultationService = consultationService;
        }
        public ResponseDTO CreateResponse(ResponseForCreationDto newResponse, int consultationId, int userId)
        {
            var response = _mapper.Map<Response>(newResponse);

            response.ConsultationId = consultationId;
            response.CreatorId = userId;

            _responseRepository.AddResponse(response);
            _responseRepository.SaveChanges();

            _consultationService.ChangeConsultationStatus(consultationId);

            return _mapper.Map<ResponseDTO>(response);
        }

        public ResponseDTO? GetResponse(int responseId)
        {
            var response = _responseRepository.GetResponse(responseId);
            return _mapper.Map<ResponseDTO>(response);
        }
    }
}
