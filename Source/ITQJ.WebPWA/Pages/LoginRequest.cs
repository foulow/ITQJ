using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITQJ.WebPWA.Pages
{
    public class LoginRequest
    {
        [Required]
        [StringLength(25)]
        public string user { get; set; }

        [Required]
        [StringLength(25)]
        public string password { get; set; }
    }
}
