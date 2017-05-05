using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EHT.WebApp.Models.ViewModels
{
    public class CompanyViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Remark { get; set; }
        public bool HasAccount { get; set; }
    }
}
