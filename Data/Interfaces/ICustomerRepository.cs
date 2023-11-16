using Api.Entities;

namespace Api.Data.Interfaces
{
    public interface ICustomerRepository 
    {
        Customer? GetCustomerById(int userId);
        //ICollection<Customer> GetStudentSubjects(int studentId);
    }
}
