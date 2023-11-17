using Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllerss
{
    [Route("api/customer")]
    [ApiController]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServices _customerServices;
        
        public CustomerController(ICustomerServices customerServices)
        {
            this._customerServices = customerServices;
        }
        //Veremos
    }
}
