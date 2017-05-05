using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EHT.WebApp.Models.Database
{
    public class Package
    {
        //[Key]
        //public int RecId { get; set; }
        public string PackageID { get; set; }
        public int Day { get; set; }
        public string Event { get; set; }
        public string Title { get; set; }
    }
}
