using Api.Data.Interfaces;
using Api.DBContext;

namespace Api.Data.Implementation
{
    public class Repository : IRepository
    {
        internal readonly CustumerCosultationContext _context;

        public Repository(CustumerCosultationContext context)
        {
            this._context = context;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
