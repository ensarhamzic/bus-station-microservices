﻿using System.ComponentModel.DataAnnotations;

namespace ApiGateway.Data.ViewModels
{
    public class AddLocationVM
    {
        [Required]
        public string Name { get; set; } = String.Empty;
        [Required]
        public string City { get; set; } = String.Empty;
        [Required]
        public string Address { get; set; } = String.Empty;
    }
}
