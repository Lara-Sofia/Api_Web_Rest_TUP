using Api.Entities;
using Api.Models;

namespace Api.Services.Interfaces
{
    public interface ICustomAuthenticationService
    {
        User? ValidateUser(AuthenticationRequestBody authenticationRequestBody);
    }
}
