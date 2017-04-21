using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using EHT.WebApp.Functions;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EHT.WebApp.Controllers
{
    public class EmailController : Controller
    {
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            clsFnEmail funcEmail = new clsFnEmail(
                "European Halal Tour Admin",        // From Name
                "admin@europeanhalaltour.com",      // From Email
                "Sharizan Redzuan",                 // To Name
                "sharizan_81@yahoo.com",            // To Email
                "Welcome to European Halal Tour",   // Subject
                "<span><strong>Thank you for contacting us! :)</strong></span>"     //Body Content
            );
            await funcEmail.SendEmail();

            return View();
        }
    }
}
