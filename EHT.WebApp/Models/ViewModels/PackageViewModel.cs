using EHT.WebApp.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EHT.WebApp.Models.ViewModels
{
    public class PackageViewModel
    {
        public string PackageID { get; set; }
        public string PackageName { get; set; }
        public int OrderSequence { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        public List<Package> PackageDetails { get; set; }

        public PackageViewModel()
        {
            PackageDetails = new List<Package>();
        }
    }
}
