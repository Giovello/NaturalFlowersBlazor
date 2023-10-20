using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NaturalFlowers.Models
{
    public partial class User : IdentityUser
    {
        public User()
        {
            Orders = new List<Order>();
            Reviews = new List<Review>();
        }

        public string? DeliveryAddress { get; set; } = null!;
        public string? Province { get; set; } = null!;
        public string? PostalCode { get; set; } = null!;
        public string? Country { get; set; } = null!;
        public string? FullName { get; set; } = null!;
        public bool IsBulkBuyer { get; set; } = false;
        public string? BillAddress { get; set; }
        public string? BillProvince { get; set; }
        public string? BillPostalCode { get; set; }
        public string? BillCountry { get; set; }
        public string? BusinessName { get; set; }
        public string? BusinessAddress { get; set; }
        public string? BusinessDeliveryAddress { get; set; }
        public string? BusinessPhone { get; set; }
        public bool IsAdmin { get; set; } = false;
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public ICollection<Order> Orders { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
