using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace NaturalFlowers.ViewModels
{
    public partial class UserViewModel
    {
        public UserViewModel()
        {
            Orders = new List<OrderViewModel>();
            Reviews = new List<ReviewViewModel>();
        }

        public string Id { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string DeliveryAddress { get; set; } = null!;
        public string Province { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public bool IsBulkBuyer { get; set; }
        public string? BillAddress { get; set; }
        public string? BillProvince { get; set; }
        public string? BillPostalCode { get; set; }
        public string? BillCountry { get; set; }
        public string? BusinessName { get; set; }
        public string? BusinessAddress { get; set; }
        public string? BusinessDeliveryAddress { get; set; }
        public string? BusinessPhone { get; set; }
        public bool IsAdmin { get; set; }

        public List<OrderViewModel> Orders { get; set; }
        public List<ReviewViewModel> Reviews { get; set; }
    }
}
