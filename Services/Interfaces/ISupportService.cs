using Api.Models.Consults;

namespace Api.Services.Interfaces
{
    public interface ISupportService
    {
        ICollection <ConsultationDTO> GetPendingConsultation(int userId, bool withResponses);
    }
}
