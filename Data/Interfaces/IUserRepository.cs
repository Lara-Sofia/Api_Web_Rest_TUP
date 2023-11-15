using Api.Entities;

namespace Api.Data.Interfaces
{
    public interface IUserRepository : IRepository
    {
        User? ValidateUser(AuthenticationRequestBody authenticationRequestBody);
        User? GetUserById(int userId);
        //Ahora si??
    }
}
