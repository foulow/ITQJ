using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITQJ.WebPWA.Models
{
    public class UserManagerResponse
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public string[] Errros { get; set; }
        public DateTime? ExpireDate { get; set; }
    }
}
