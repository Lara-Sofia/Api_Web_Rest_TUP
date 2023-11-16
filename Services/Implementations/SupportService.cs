using Api.Data.Interfaces;
using Api.Models.Consults;
using Api.Services.Interfaces;
using AutoMapper;

namespace Api.Services.Implementations
{
    public class SupportService : ISupportService
    {
        private readonly IMapper _mapper;
        private readonly IConsultationRepository _consultationRepository;

        public SupportService(IMapper mapper, IConsultationRepository consultationRepository)
        {
            _mapper = mapper;
            _consultationRepository = consultationRepository;
        }

        public ICollection<ConsultationDTO> GetPendingConsultation(int userId, bool withResponse)
        {
            var consultation = _consultationRepository.GetPendingConsults(userId, withResponse);
            return _mapper.Map<List<ConsultationDTO>>(consultation);

        }

       
    }
}
