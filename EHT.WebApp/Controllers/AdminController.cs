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
using EHT.WebApp.Models.Database;
using EHT.WebApp.Functions;

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
            List<PackageViewModel> model = new List<PackageViewModel>();

            try
            {
                model = _context.PackageMain
                .Select(x => new PackageViewModel
                {

                    PackageID = x.PackageID,
                    PackageName = x.PackageName,
                    OrderSequence = x.OrderSequence,
                    CreatedBy = x.CreatedBy,
                    CreatedOn = x.CreatedOn
                })
                .OrderBy(x => x.OrderSequence).ThenBy(x => x.PackageName)
                .ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult PackageDetails(string UserAction, string ID, int Day)
        {
            if (UserAction != null && UserAction == "Del")
            {
                //Delete from database
                if (ID != null)
                {
                    var rem = _context.Packages.Where(x => x.PackageID == ID && x.Day == Day).FirstOrDefault();
                    if (rem != null)
                    {
                        _context.Packages.Remove(rem);
                        _context.SaveChanges();
                    }                        
                } 

                return RedirectToAction("PackageDetails", new { ID = ID });
            }

            //Get package details based on id
            PackageViewModel model = new PackageViewModel();
            //List<Pack> modelItem = new List<PackageDetailsViewModel>();

            var data = _context.PackageMain
                .Where(x => x.PackageID == ID)
                .FirstOrDefault()
                ;

            if (data != null)
            {
                model.PackageID = data.PackageID;
                model.PackageName = data.PackageName;
                model.OrderSequence = data.OrderSequence;
                model.CreatedBy = data.CreatedBy;
                model.CreatedOn = data.CreatedOn;
            }

            //Get Package item details here...
            var packageItems = _context.Packages
                .Where(x => x.PackageID == ID)
                .OrderBy(x => x.Day)
                //.Select(x => new Package
                //{
                //})
                .ToList();

            model.PackageDetails.AddRange(packageItems);

            //Add extra for user to add new
            Package newPackage = new Models.Database.Package();
            model.PackageDetails.Add(newPackage);

            return View(model);

        }

        [HttpPost]
        public IActionResult PackageDetails(PackageViewModel model)
        {
            //Before save, remove day with 0 value
            try
            {
                if (model.PackageID == null)
                {
                    model.PackageID = clsGeneral.CreateRandomCode(10);
                }

                var itemToUpdate = _context.PackageMain.Where(x => x.PackageID == model.PackageID).FirstOrDefault();
                if (itemToUpdate == null)
                {
                    //Save new
                    PackageMain data = new PackageMain();
                    data.PackageID = model.PackageID;
                    data.PackageName = model.PackageName;
                    data.OrderSequence = model.OrderSequence;
                    data.CreatedBy = User.Identity.Name;
                    data.CreatedOn = DateTime.Now;

                    _context.PackageMain.Add(data);
                } else
                {
                    //Update
                    itemToUpdate.PackageName = model.PackageName;
                    itemToUpdate.OrderSequence = model.OrderSequence;
                    itemToUpdate.CreatedBy = User.Identity.Name;

                    //Remove all the details and re-insert
                    if (model.PackageDetails.Count > 0)
                    {                    
                        var del = _context.Packages.Where(x => x.PackageID == model.PackageID);
                        _context.Packages.RemoveRange(del);
                        _context.SaveChanges();
                    }
                }

                //Save the details
                foreach (Package item in model.PackageDetails)
                {
                    if (item.Day > 0)
                    {
                        item.PackageID = model.PackageID;
                        _context.Packages.Add(item);
                    }
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {
                
            }
            return RedirectToAction("PackageDetails", "Admin", new { ID = model.PackageID });
            //return RedirectToAction("Package", "Admin");

        }

        [HttpGet]
        public IActionResult PackageDelete(string ID)
        {
            //Get package details based on id
            PackageViewModel model = new PackageViewModel();

            var data = _context.PackageMain
                .Where(x => x.PackageID == ID)
                .FirstOrDefault()
                ;

            if (data != null)
            {
                model.PackageID = data.PackageID;
                model.PackageName = data.PackageName;
                model.OrderSequence = data.OrderSequence;
                model.CreatedBy = data.CreatedBy;
                model.CreatedOn = data.CreatedOn;
            }

            //Get Package item details here...
            var packageItems = _context.Packages
                .Where(x => x.PackageID == ID)
                .OrderBy(x => x.Day)
                .ToList();

            model.PackageDetails.AddRange(packageItems);

            return View(model);
        }

        [HttpPost]
        public IActionResult PackageDelete(PackageViewModel model)
        {
            if (model.PackageID != null)
            {
                var itemDel = _context.PackageMain.Where(x => x.PackageID == model.PackageID).FirstOrDefault();
                if (itemDel != null)
                {
                    _context.PackageMain.Remove(itemDel);

                    var packDetails = _context.Packages.Where(x => x.PackageID == model.PackageID);
                    if (packDetails != null)
                    {
                        _context.Packages.RemoveRange(packDetails);
                    }
                }

                _context.SaveChanges();
            }

            return RedirectToAction("Package", "Admin");
        }

    }
}
