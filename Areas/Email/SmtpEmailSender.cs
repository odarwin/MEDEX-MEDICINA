using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Net;

namespace ProyectoMedexcard.Areas.Email
{
    public class SmtpEmailSender
    {
        private readonly SmtpSettings _smtpSettings;
        public SmtpEmailSender(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            using (SmtpClient client = new SmtpClient())
            {
                client.Host = _smtpSettings.Host;
                client.Port = _smtpSettings.Port;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(_smtpSettings.UserName, _smtpSettings.Password);
                client.EnableSsl = true;

                using (MailMessage mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress(_smtpSettings.SenderEmail, _smtpSettings.SenderName);
                    mailMessage.To.Add(email);
                    mailMessage.Subject = subject;
                    mailMessage.Body = message;
                    mailMessage.IsBodyHtml = true;

                    await client.SendMailAsync(mailMessage);
                }
            }
        }
    }
}
