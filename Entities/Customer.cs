namespace Api.Entities
{
    public class Customer : User
    {
        public ICollection<Consultation> Consultation { get; set; } = new List<Consultation>();
    }
}
