using Api.Data.Interfaces;
using Api.Entities;
using Api.Models.Consults;
using Api.Services.Interfaces;
using AutoMapper;
using static Api.Services.Implementations.CustomerService;

namespace Api.Services.Implementations
{
    public class CustomerService : ICustomerServices
    {
        private readonly ICustomerRepository _userRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _userRepository = customerRepository;
            _mapper = mapper;
        }
        public ICollection<ConsultationDTO> GetCustomerById(int userId)
        {
            var consultation = _userRepository.GetCustomerById(userId);

            return _mapper.Map<ICollection<ConsultationDTO>>(consultation);
        }
    }
}
