﻿namespace ITQJ.WebPWA.VMs
{
    public class UserVM
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public string Email { get; set; }

        public RolVM Rol { get; set; }
    }
}
