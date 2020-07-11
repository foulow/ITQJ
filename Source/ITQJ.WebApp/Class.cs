using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITQJ.WebApp
{
    public class Class
    {
        [Required]
        [StringLength(25)]
        public string User { get; set; }
            
        [Required]
        [StringLength(25)]
        public string password { get; set; }
    }
}
