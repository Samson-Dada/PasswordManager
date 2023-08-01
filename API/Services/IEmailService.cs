namespace API.Services
{
    public interface IEmailService
    {
        Task SendMail(string recipentEmail, string subject, string body);
    }
}
