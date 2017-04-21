using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EHT.WebApp.Controllers
{
    public class EmailController : Controller
    {
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("European Halal Tour Admin", "admin@europeanhalaltour.com"));
            emailMessage.To.Add(new MailboxAddress("Sharizan Redzuan", "sharizan_81@yahoo.com"));
            emailMessage.Subject = "Welcome to European Halal Tour";
            emailMessage.Body = new TextPart("plain") { Text = "I hope you get what you want ya!" };

            using (var client = new SmtpClient())
            {
                client.LocalDomain = "europeanhalaltour.com";
                await client.ConnectAsync("n1smtpout.europe.secureserver.net", 25, SecureSocketOptions.None).ConfigureAwait(false);
                await client.SendAsync(emailMessage).ConfigureAwait(false);
                await client.DisconnectAsync(true).ConfigureAwait(false);
            }

            return View();
        }
    }
}
