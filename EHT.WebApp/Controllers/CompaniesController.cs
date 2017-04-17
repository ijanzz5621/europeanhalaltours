using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EHT.WebApp.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EHT.WebApp.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly DatabaseDbContext _context;

        public CompaniesController(DatabaseDbContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var companies = _context.Companies.ToList();

            return View(companies);
        }
    }
}
