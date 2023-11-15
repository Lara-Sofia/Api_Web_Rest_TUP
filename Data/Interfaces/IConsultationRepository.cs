using Api.Entities;
using System;

namespace Api.Data.Interfaces
{
    public interface IConsultationRepository : IRepository
    {
        void AddConsult(Consultation newConsult);
        IOrderedQueryable<Consultation> GetPendingConsults(int userId, bool withResponses);
        Consultation? GetConsult(int consultationId);
        bool IsConsultIdValid(int consultationId);
    }
}
