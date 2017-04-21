using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EHT.WebApp.Functions
{
    public class clsFnEmail
    {
        public string FromName { get; set; }
        public string FromEmail { get; set; }
        public string ToName { get; set; }
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public clsFnEmail(string fromName, string fromEmail, string toName, string toEmail, string subject, string content)
        {
            FromName = fromName;
            FromEmail = fromEmail;
            ToName = toName;
            ToEmail = toEmail;
            Subject = subject;
            Content = content;
        }

        public async Task SendEmail()
        {
            try
            {
                var emailMessage = new MimeMessage();

                emailMessage.From.Add(new MailboxAddress(FromName, FromEmail));
                emailMessage.To.Add(new MailboxAddress(ToName, ToEmail));
                emailMessage.Subject = Subject;
                //emailMessage.Body = new TextPart("plain") { Text = "I hope you get what you want ya!" };

                //Html body
                var bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = @"" + Content;
                emailMessage.Body = bodyBuilder.ToMessageBody();

                using (var client = new SmtpClient())
                {
                    client.LocalDomain = "europeanhalaltour.com";
                    await client.ConnectAsync("n1smtpout.europe.secureserver.net", 25, SecureSocketOptions.None).ConfigureAwait(false);
                    await client.SendAsync(emailMessage).ConfigureAwait(false);
                    await client.DisconnectAsync(true).ConfigureAwait(false);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
