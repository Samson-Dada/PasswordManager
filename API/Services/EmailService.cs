using MailKit.Net.Smtp;
using MimeKit;
using MailKit.Security;

namespace API.Services
{
    public  class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        public EmailService(IConfiguration configuration)
        {

            _configuration = configuration;

        }
        public  async Task SendMail(string recipentEmail, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Samson", "sam@gmail.com"));
            message.To.Add(new MailboxAddress("", recipentEmail));
            message.Subject = subject;

            var bodyBulder = new BodyBuilder
            {
                HtmlBody = body
                
            };
            message.Body = bodyBulder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_configuration.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);

                string email = _configuration.GetConnectionString("EmailSettings:EmailAddress");
                string password = _configuration.GetConnectionString("EmailSettings:EmailPassword");
                await client.AuthenticateAsync(email, password);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }
    }
}
