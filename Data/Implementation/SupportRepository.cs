using Api.Data.Interfaces;
using Api.DBContext;
using Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementation
{
    public class SupportRepository : Repository, ISupportRepository
    {
        public SupportRepository(CustumerCosultationContext context) : base(context)
        {
        }

        public Support? GetProfessorById(int userId) => _context.Support.Find(userId);

        public Support? GetSupportById(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
