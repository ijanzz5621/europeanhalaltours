using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using EHT.WebApp.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EHT.WebApp.Controllers
{
    //[Authorize]
    public class PackageController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PackageDetails(string id)
        {
            PackageDetailsViewModel model = new PackageDetailsViewModel();
            if (id == "")
            {

            }

            return View(model);
        }
    }
}
