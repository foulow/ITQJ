using ITQJ.Domain.DTOs;
using ITQJ.WebClient.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace ITQJ.WebClient.ViewModels
{
    public class MileStoneVM : MileStoneResponseDTO
    {
        public IFormFile FormFile { get; set; }
    }
}