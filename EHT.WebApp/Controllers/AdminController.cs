using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EHT.WebApp.Data;
using EHT.WebApp.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EHT.WebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly DatabaseDbContext _context;

        public AdminController(DatabaseDbContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            //var companies = _context.Companies.ToList();
            return View();
        }

        public IActionResult Company()
        {
            var companies = _context.Companies
                .Select(x => new CompanyViewModel {
                })
                .ToList();

            return View(companies);
        }

        public IActionResult Package()
        {
            return View();
        }
    }
}
