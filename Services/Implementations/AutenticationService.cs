using Api.Data.Interfaces;
using Api.Entities;
using Api.Models;
using Api.Services.Interfaces;

namespace Api.Services.Implementations
{
    public class AutenticationService : ICustomAuthenticationService
    {
        private readonly IUserRepository _userRepository;

        public AutenticationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User? ValidateUser(AuthenticationRequestBody authenticationRequest)
        {
            if (string.IsNullOrEmpty(authenticationRequest.UserName) || string.IsNullOrEmpty(authenticationRequest.Password))
                return null;

            return _userRepository.ValidateUser(authenticationRequest);
        }
    }
}


