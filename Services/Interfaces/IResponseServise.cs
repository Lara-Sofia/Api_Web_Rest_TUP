using Api.Models.Responses;

namespace Api.Services.Interfaces
{
    public interface IResponseService
    {
        ResponseDTO CreateResponse(ResponseForCreationDto newResponse, int questionId, int userId);
        ResponseDTO? GetResponse(int responseId);
    }
}
