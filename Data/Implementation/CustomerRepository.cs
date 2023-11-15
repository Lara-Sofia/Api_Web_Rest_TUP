using Api.Data.Interfaces;
using Api.DBContext;
using Api.Entities;

namespace Api.Data.Implementation
{
    public class CustomerRepository : Repository, ICustomerRepository
    {
        public CustomerRepository(CustumerCosultationContext context) : base(context)
        {
        }

        public Customer? GetCustomerById(int userId) => _context.Customers.Find(userId);

    }
}
