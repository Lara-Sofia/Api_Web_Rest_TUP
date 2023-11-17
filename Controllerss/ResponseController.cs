using Api.Models;
using Api.Models.Responses;
using Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Api.Controllerss
{
    [ApiController]
    [Authorize]
    [Route("api/Consult/{consultationId}/response")]
    public class ResponseController : ControllerBase
    {
        private readonly IResponseService _responseService;
        private readonly IConsultationService _consultService;

        public ResponseController(IResponseService responseService, IConsultationService consultService)
        {
            _responseService = responseService;
            this._consultService = consultService;
        }

        [HttpGet("{responseId}", Name = "GetResponse")]
        public ActionResult<ResponseDTO> GetConsultation(int responseId)
        {
            var response = _responseService.GetResponse(responseId);

            if (response is null)
                return NotFound();

            return Ok(response);
        }

        [HttpPost]
        public IActionResult CreateResponse(int consultId, ResponseForCreationDto newResponseForCreation)
        {
            if (!_consultService.IsConsultationIdValid(consultId))
                return NotFound($"Question Id not found: {consultId.ToString()}");
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var userId = int.Parse(userIdClaim);

            var newResponse = _responseService.CreateResponse(newResponseForCreation, consultId, userId);

            return CreatedAtRoute(
                "GetResponse",
                new { consultId = consultId, responseId = newResponse.Id },
                newResponse);
        }

      

        [HttpPut]
        public ActionResult<ResponseDTO> Put(int consultationId)
        {
            //lala 
        }

        [HttpDelete]
        public ActionResult<ResponseDTO> Delete(int consultationId)
        {
            //lala 
        }
    }
}
