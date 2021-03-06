﻿using System;
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
        [MaxLength(10)]
        public string PackageID { get; set; }
        public int Day { get; set; }
        public string Event { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
    }
}
