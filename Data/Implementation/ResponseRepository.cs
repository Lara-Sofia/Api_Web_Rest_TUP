using Api.Data.Interfaces;
using Api.DBContext;
using Api.Entities;

namespace Api.Data.Implementation
{
    public class ResponseRepository : Repository, IResponseRepository
    {
        public ResponseRepository(CustumerCosultationContext context) : base(context)
        {
        }

        public void AddResponse(Response newResponse)
        {
            _context.Responses.Add(newResponse);
        }

        public Response? GetResponse(int responseId)
        {
            return _context.Responses.Find(responseId);
        }
    }
}
