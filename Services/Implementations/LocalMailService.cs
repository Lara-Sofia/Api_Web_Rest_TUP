using Api.Services.Interfaces;

namespace Api.Services.Implementations
{
    public class LocalMailService : IMailService
    {
        private readonly string _mailFrom = string.Empty;

        public LocalMailService(IConfiguration configuration)
        {
            _mailFrom = configuration["mailSettings:mailFromAddress"];
        }

        public void Send(string consult, string message, string mailTo)
        {
            Console.WriteLine($"Mail de {_mailFrom} a {mailTo}, " +
                $"con {nameof(LocalMailService)}.");
            Console.WriteLine($"Consulta: {consult}");
            Console.WriteLine($"Mensaje: {message}");
        }
    }
}
