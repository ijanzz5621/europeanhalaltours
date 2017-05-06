using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using EHT.WebApp.Models.ViewModels;
using EHT.WebApp.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

using EHT.WebApp.Models.Database;

namespace EHT.WebApp.Controllers
{
    [Authorize]
    public class PackageController : Controller
    {
        private readonly DatabaseDbContext _context;

        public PackageController(DatabaseDbContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<PackageViewModel> model = new List<PackageViewModel>();
            model = _context.PackageMain
                .OrderBy(x => x.OrderSequence).ThenBy(x => x.PackageName)
                .Select(x => new PackageViewModel
                {
                    PackageID = x.PackageID,
                    PackageName = x.PackageName
                })
                .ToList();

            return View(model);
        }

        public IActionResult PackageDetails(string id)
        {
            PackageDetailsViewModel model = new PackageDetailsViewModel();
            if (id != "")
            {
                var data = _context.Packages.Where(x => x.PackageID == id).OrderBy(x => x.Day).ToList();

                if (data != null && data.Count > 0)
                {
                    model.PackageCode = data.First().PackageID;
                    foreach (Package package in data)
                    {
                        PackageDetailsDayEvents item = new PackageDetailsDayEvents();
                        item.Day = package.Day;
                        item.Title = package.Title;
                        item.Event = package.Event;

                        model.Events.Add(item);
                    }
                }                
            }

            return View(model);
        }
    }
}
