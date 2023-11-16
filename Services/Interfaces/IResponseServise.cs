using Api.Models.Responses;

namespace Api.Services.Interfaces
{
    public interface IResponseService
    {
        ResponseDTO CreateResponse(ResponseForCreationDto newResponse, int consultationId, int userId);
        ResponseDTO? GetResponse(int responseId);
    }
}
