using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;

namespace FitnessUygulamasi.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // Mail gönderme işlemini boş geçiyoruz, hata vermesin yeter.
            return Task.CompletedTask;
        }
    }
}