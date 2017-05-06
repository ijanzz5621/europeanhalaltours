using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EHT.WebApp.Models.Database
{
    public class PackageMain
    {
        [Required]
        [Key]
        [MaxLength(10)]
        public string PackageID { get; set; }
        [MaxLength(50)]
        public string PackageName { get; set; }
        public DateTime CreatedOn { get; set; }
        [MaxLength(50)]
        public string CreatedBy { get; set; }
        public int OrderSequence { get; set; }

        public PackageMain()
        {
            OrderSequence = 0;
        }
    }
}
