using Api.Entities;

namespace Api.Data.Interfaces
{
    public interface IResponseRepository : IRepository
    {
        void AddResponse(Response newResponse);
        Response? GetResponse(int responseId);
    }
}
