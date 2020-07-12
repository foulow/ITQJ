using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITQJ.WebPWA.Pages
{
    public class UserManagerResponse
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public string[] Errors { get; set; }
        public Dictionary<string,string> UserInfo { get; set; }
        public DateTime? ExpireDate { get; set; }
    }
}
