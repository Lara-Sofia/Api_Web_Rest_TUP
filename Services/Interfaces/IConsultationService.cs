using Api.Enums;
using Api.Models.Consults;

namespace Api.Services.Interfaces
{
    public interface IQuestionService
    {
        ConsultationDTO CreateConsultation(ConsultationForCreationDto newConsultation, int userId);
        ConsultationDTO GetConsultation(int consultationId);
        bool IsConsultationIdValid(int consultationId);
        void ChangeConsultationStatus(int consultationId, ConsultationState status);
        void ChangeConsultationStatus(int consultationId);
    }
}
