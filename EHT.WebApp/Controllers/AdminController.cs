using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EHT.WebApp.Data;
using EHT.WebApp.Models.ViewModels;
using EHT.WebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EHT.WebApp.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly DatabaseDbContext _context;
        //private UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _usercontext;

        public AdminController(
            DatabaseDbContext context,
            //UserManager<ApplicationUser> userManager
            ApplicationDbContext usercontext
            )
        {
            _context = context;
            //_userManager = userManager;
            _usercontext = usercontext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            //var companies = _context.Companies.ToList();
            return View();
        }

        public IActionResult Company()
        {
            List<CompanyViewModel> model = new List<CompanyViewModel>();

            //ApplicationUser user = new ApplicationUser();
            //user = _userManager.Users.FirstOrDefault(x => x.Email == "sharizan_81@yahoo.com");

            try
            {
                model = _context.Companies
                .Select(x => new CompanyViewModel
                {

                    Name = x.Name,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                    Remark = x.Remark
                    ,
                    //HasAccount = (_userManager.Users.Where(y => y.Email == "123").SingleOrDefault() != null) ? true : false
                    //HasAccount = (_usercontext.Users.Where(y => y.Email == x.Email).SingleOrDefault() == null) ? false : true
                })
                .ToList();


                if (model.Count > 0)
                {
                    for (int i = 0; i < model.Count; i++)
                    {
                        ApplicationUser user = _usercontext.Users.Where(x => x.Email == model[i].Email).SingleOrDefault();
                        model[i].HasAccount = (user == null) ? false : true;
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            

            return View(model);
        }

        public IActionResult Package()
        {
            return View();
        }
    }
}
