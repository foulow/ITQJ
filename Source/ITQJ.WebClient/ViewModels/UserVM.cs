using AutoMapper.Configuration.Annotations;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace ITQJ.WebClient.ViewModels
{
    public class UserVM
    {
        [Ignore]
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public int RolId { get; set; }

        [Ignore]
        public RolVM Rol { get; set; }

        [Ignore]
        public List<RolVM> Roles { get; set; }
    }
}
