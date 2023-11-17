namespace Api.Services.Interfaces
{
    public interface IMailService
    {
        void Send(string message, string mailTo);
    }
}
