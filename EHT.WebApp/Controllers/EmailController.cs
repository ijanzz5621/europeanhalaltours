using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EHT.WebApp.Controllers
{
    public class EmailController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            //MailMessage msg = new MailMessage();
            //// Add your email address to the recipients
            //msg.To.Add("mr@soundout.net");
            //// Configure the address we are sending the mail from
            //MailAddress address = new MailAddress("mr@soundout.net");
            //msg.From = address;
            //msg.Subject = txtSubject.Text;
            //msg.Body = txtName.Text + "n" + txtEmail.Text + "n" + txtMessage.Text;

            //SmtpClient client = new SmtpClient();
            //client.Host = "relay-hosting.secureserver.net";
            //client.Port = 25;

            //// Send the msg
            //client.Send(msg);

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Sharizan", "eht@ijglobaltech.com"));
            message.To.Add(new MailboxAddress("Sharizan", "sharizan.mohdredzuan@microchip.com"));
            message.Subject = "Hello World - A mail from Go Daddy!!";
            //message.Body = new TextPart("plain")
            //{
            //    Text = "Hello World - A mail from ASPNET Core"
            //};

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = @"<b>This is bold and this is <i>italic</i></b>";
            message.Body = bodyBuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {                
                client.Connect("n1smtpout.europe.secureserver.net", 25, false);                
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                // Note: since we don't have an OAuth2 token, disable 	
                // the XOAUTH2 authentication mechanism.     
                //client.Authenticate("eht@ijglobaltech.com", "1j@nPHT6420");
                client.Send(message);
                client.Disconnect(true);
            }

            return View();
        }
    }
}
