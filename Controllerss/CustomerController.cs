using Api.Models;
using Api.Models.Consults;
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
        [HttpGet]
        public ActionResult<CustomerDTO> Get(int consultationId)
        {
            //lala 
        }
        [HttpPost]
        public ActionResult<CustomerDTO> Post(int consultationId)
        {
            //lala 
        }

        [HttpPut]
        public ActionResult<CustomerDTO> Put(int consultationId)
        {
            //lala 
        }

        [HttpDelete]
        public ActionResult<CustomerDTO> Delete(int consultationId)
        {
            //lala 
        }
    }
}
