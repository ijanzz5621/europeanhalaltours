using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EHT.WebApp.Models
{
    public class RequestAccountModel
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Code { get; set; }
        [Required]
        [Display(Name="Phone Number")]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }

        public string Remark { get; set; }
    }
}
