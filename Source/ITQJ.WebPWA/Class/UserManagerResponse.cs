namespace ITQJ.WebPWA.Class
{
    using System;
    using System.Collections.Generic;

    public class UserManagerResponse
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public string[] Errors { get; set; }
        public Dictionary<string,string> UserInfo { get; set; }
        public DateTime? ExpireDate { get; set; }
    }
}
