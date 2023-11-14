namespace Api.Entities
{
    public class Support : User
    {
        public ICollection<Consultation> Consultations { get; set; } = new List<Consultation>();
    }
}
