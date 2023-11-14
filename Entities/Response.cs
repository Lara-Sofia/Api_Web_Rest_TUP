using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api.Entities
{
    public class Response
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime CreationDate { get; } = DateTime.Now.ToUniversalTime();
        [ForeignKey("CreatorId")]
        public User Creator { get; set; } //relaciona el usuario
        public int CreatorId { get; set; }
        [ForeignKey("ConsultationId")]
        public Consultation Consultation { get; set; }
        public int ConsultationId { get; set; }
    }
}
