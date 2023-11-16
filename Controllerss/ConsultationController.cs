using Api.Models.Consults;
using Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Api.Controllerss
{
    [Route("api/question")]
    [ApiController]
    [Authorize]
    public class ConsultationController : ControllerBase
    {
        private readonly IConsultationService _consultationService;
        public ConsultationController(IConsultationService consultationService)
        {
            this._consultationService = consultationService;
        }

        [HttpGet("{consultId}", Name = "GetConsult")]
        public ActionResult<ConsultationDTO> GetConsultation(int consultationId)
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (!int.TryParse(userIdClaim, out int userId))
            {
                return Unauthorized();
            }

            var consult = _consultationService.GetConsultation(consultationId);

            if (consult is null)
                return NotFound();

            if (consult.CreatorCustomerId != userId)
                return Forbid();

            return Ok(consult);
        }

    }
}
