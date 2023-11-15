using Api.Data.Interfaces;
using Api.DBContext;
using Api.Entities;

namespace Api.Data.Implementation
{
    public class UserRepository : Repository, IUserRepository
    {
        public UserRepository(CustumerCosultationContext context) : base(context)
        {
        }

        public User? GetUserById(int userId)
        {
            return _context.Users.Find(userId);
        }

        public User? ValidateUser(AuthenticationRequestBody authRequestBody)
        {
            if (authRequestBody.UserType == "custumer")
                return _context.Customers.FirstOrDefault(p => p.UserName == authRequestBody.UserName && p.Password == authRequestBody.Password);
            return _context.Supports.FirstOrDefault(p => p.UserName == authRequestBody.UserName && p.Password == authRequestBody.Password);
        }
    }
}
