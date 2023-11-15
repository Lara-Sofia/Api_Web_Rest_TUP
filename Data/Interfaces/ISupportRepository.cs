using Api.Entities;

namespace Api.Data.Interfaces
{
    public interface ISupportRepository
    {
        Support? GetSupportById(int userId);
    }
}
