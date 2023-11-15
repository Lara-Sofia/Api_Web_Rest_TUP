using Api.Enums;
using Api.Models.Responses;

namespace Api.Models.Consults
{
    public class ConsultationDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int SupportId { get; set; }
        public int CreatorCustomerId { get; set; }
        //public int SubjectId { get; set; }
        public ICollection<ResponseDTO> Responses { get; set; } = new List<ResponseDTO>();
        public ConsultationState ConsultationState { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? LastModificationDate { get; set; }
    }
}
