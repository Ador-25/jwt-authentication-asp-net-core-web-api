using System.Net;
using System.Net.Mail;

namespace Auth.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            var mail = "khosruzzaman802@gmail.com";
            var pw = "khosru890";
            //khosru320@outlook.com
            //Mon.smz320


            //khosruzzaman802@gmail.com
            //khosru890
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(mail,pw)
            };

            return client.SendMailAsync(
                new MailMessage(from: mail,
                                to: email,
                                subject,
                                message
                                ));
        }
    }
}
