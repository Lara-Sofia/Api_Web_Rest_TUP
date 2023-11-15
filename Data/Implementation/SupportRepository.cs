using Api.Data.Interfaces;
using Api.DBContext;
using Api.Entities;
using static Api.Data.Implementation.SupportRepository;

namespace Api.Data.Implementation
{
    public class SupportRepository : Repository, ISupportRepository
    {
        public SupportRepository(CustumerCosultationContext context) : base(context)
        {
        }

        public Support? GetSupportById(int userId) => _context.Supports.Find(userId);
    }
}
