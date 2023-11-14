using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Api.Enums;

namespace Api.Entities
{
    public class Consultation
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [ForeignKey("SupportId")]
        public Support AssignedSupport { get; set; }
        public int SupportId { get; set; }
        [ForeignKey("CreatorCustomerId")]
        public Customer Customer { get; set; }
        public int CreatorCustomerId { get; set; }
        public ICollection<Response> Responses { get; set; } = new List<Response>();
        public ConsultationState ConsultationState { get; set; } = ConsultationState.WaitingSupportAnwser;
        public DateTime CreationDate { get; private set; } = DateTime.Now.ToUniversalTime(); 
        public DateTime? EndDate { get; set; }
        public DateTime? LastModificationDate { get; set; } = DateTime.Now.ToUniversalTime();
    }
}
