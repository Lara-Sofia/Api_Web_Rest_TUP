using Api.Data.Interfaces;
using Api.Entities;
using Api.Enums;
using Api.Models.Consults;
using Api.Services.Interfaces;
using AutoMapper;
using System.Security.Claims;

namespace Api.Services.Implementations
{
    public class ConsultationService : IConsultationService
    {
        private readonly IMapper _mapper;
        private readonly IConsultationRepository _consultationRepository;
        private readonly IMailService _mailService;
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _httpContext;

        public ConsultationService(IMapper mapper,
            IConsultationRepository consultationRepository,
            IMailService mailService,
            IUserRepository userRepository,
            IHttpContextAccessor httpContext)
        {
            _mapper = mapper;
            _consultationRepository = consultationRepository;
            _mailService = mailService;
            _userRepository = userRepository;
            this._httpContext = httpContext;
        }

        public ConsultationDTO CreateConsultation(ConsultationForCreationDto newConsultationDto, int userId)
        {
            var newConsultation = _mapper.Map<Entities.Consultation>(newConsultationDto);

            newConsultation.CreatorCustomerId = userId;

            var costumer = _userRepository.GetUserById(userId);
            var support = _userRepository.GetUserById(newConsultationDto.AssignedSupportId);

            _consultationRepository.AddConsult(newConsultation);
            if (_consultationRepository.SaveChanges())
                _mailService.Send("Consulta nueva creada,",
                    $"El cliente: {costumer.Name} {costumer.LastName} tiene una nueva consulta",
                    support.Email);

            return _mapper.Map<ConsultationDTO>(newConsultation);
        }


        

        public void ChangeConsultationStatus(int consultationId, ConsultationState newStatus)
        {
            var consult = _consultationRepository.GetConsult(consultationId);
            consult.LastModificationDate = DateTime.Now;
            consult.ConsultationState = newStatus;
            if (_consultationRepository.SaveChanges())
                NotifyStatusChange(consult);
        }

        public void ChangeConsultationStatus(int consultationId)
        {
            var userId = _httpContext.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var consult = _consultationRepository.GetConsult(consultationId);
            var user = _userRepository.GetUserById(int.Parse(userId));
            consult.ConsultationState = user.UserType == "costumers" ? ConsultationState.WaitingSupportAnwser : ConsultationState.WaitingSupportAnwser;
            consult.LastModificationDate = DateTime.Now;
            if (_consultationRepository.SaveChanges())
                NotifyStatusChange(consult);
        }

        private void NotifyStatusChange(Consultation consult)
        {
            _mailService.Send("Se modificó una consulta",
                $"Usted tiene una notificación de su consulta: {consult.Title}",
                consult.Customer.Email);

            _mailService.Send("Se modificó una consulta",
                $"La pregunta '{consult.Title}' ahora tiene un estado: {consult.ConsultationState.ToString()}",
                consult.AssignedSupport.Email);
        }

        public ConsultationDTO GetConsultation(int consultationId)
        {
            var consulta = _consultationRepository.GetConsult(consultationId);
            return _mapper.Map<ConsultationDTO?>(consulta);

        }

        public bool IsConsultationIdValid(int consultationId)
        {
            return _consultationRepository.IsConsultIdValid(consultationId);
        }

    }
}
