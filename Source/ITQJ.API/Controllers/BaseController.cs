using AutoMapper;
using ITQJ.EFCore;
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
            this._serviceProvider = serviceProvider;
            this._appDBContext = serviceProvider.GetRequiredService<ApplicationDBContext>();
            this._mapper = serviceProvider.GetRequiredService<IMapper>();
        }
    }
}
