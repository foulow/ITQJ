﻿using AutoMapper;
using ITQJ.EFCore.DbContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ITQJ.API.Controllers
{
    public class BaseController : ControllerBase
    {
        protected readonly IServiceProvider _serviceProvider;
        protected readonly ApplicationDBContext _appDBContext;
        protected readonly IMapper _mapper;

        public BaseController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _appDBContext = serviceProvider.GetRequiredService<ApplicationDBContext>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
        }
    }
}
