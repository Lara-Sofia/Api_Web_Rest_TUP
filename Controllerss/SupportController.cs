using Api.Entities;
using Api.Models.Consults;
using Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Api.Controllerss
{
    [ApiController]
    [Authorize]
    [Route("api/support")]
    public class SupportController : Controller
    {
        private readonly ISupportService _supportService;

        public SupportController(ISupportService supportService)
        {
            this._supportService = supportService;
        }

        [HttpGet("pendingconsultation")]
        public ActionResult<ICollection<ConsultationDTO>> GetPendingConsultations(bool withResponse = false)
        {
            var user = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (userRole != "support")
                return Forbid();

            return _supportService.GetPendingConsultation(int.Parse(user), withResponse).ToList();
        }

        
        
    }
}
