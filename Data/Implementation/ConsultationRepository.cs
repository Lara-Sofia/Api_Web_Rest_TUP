using Api.Data.Interfaces;
using Api.DBContext;
using Api.Entities;
using Api.Enums;
using Microsoft.EntityFrameworkCore;
using System;

namespace Api.Data.Implementation
{
    public class ConsultationRepository : Repository, IConsultationRepository
    {
        public ConsultationRepository(CustumerCosultationContext context) : base(context)
        {
        }

        public void AddConsult(Consultation newConsult)
        {
            _context.Consultations.Add(newConsult);
        }

        public Consultation? GetConsult(int consultationId)
        {
            return _context.Consultations
                .Include(q => q.AssignedSupportId)
                .Include(q => q.Customer)
                .FirstOrDefault(c => c.Id == consultationId);
        }

        public IOrderedQueryable<Consultation> GetPendingConsults(int userId, bool withResponses)
        {
            if (withResponses)
                return _context.Consultations
                    .Include(q => q.Responses).ThenInclude(r => r.Creator)
                    .Where(q => q.AssignedSupportId == userId && q.ConsultationState == ConsultationState.WaitingSupportAnwser)
                    .OrderBy(q => q.LastModificationDate);
            return _context.Consultations
                .Where(q => q.AssignedSupportId == userId && q.ConsultationState == ConsultationState.WaitingSupportAnwser)
                .OrderBy(q => q.LastModificationDate);
        }

        public bool IsConsultIdValid(int consultationId)
        {
            return _context.Consultations.Any(q => q.Id == consultationId);
        }
    }
}
