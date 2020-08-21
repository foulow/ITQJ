using ITQJ.Domain.DTOs;
using System;

namespace ITQJ.WebClient.ViewModels
{
    public class ReviewCreateVM : ReviewResponseDTO
    {
        public string ReviewerRole { get; set; }

        public Guid PostulantId { get; set; }
    }
}