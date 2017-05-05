using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EHT.WebApp.Models.ViewModels
{
    public class PackageDetailsViewModel
    {
        public string PackageCode { get; set; }
        public List<PackageDetailsDayEvents> Events { get; set; } = new List<PackageDetailsDayEvents>();
    }

    public class PackageDetailsDayEvents
    {
        public int Day { get; set; }
        public string Event { get; set; }
    }

}
