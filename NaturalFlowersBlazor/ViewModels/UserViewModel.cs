using Microsoft.AspNetCore.Identity;
using NaturalFlowers.Models;
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

        public UserViewModel(User user)
        {
            Orders = new List<OrderViewModel>();
            Reviews = new List<ReviewViewModel>();

            this.Id = user.Id;
            this.Email = user.Email;
            this.FullName = user.FullName;
            this.DeliveryAddress = user.DeliveryAddress;
            this.IsAdmin = user.IsAdmin;
            this.IsBulkBuyer = user.IsBulkBuyer;

            this.BusinessAddress = user.BusinessAddress;
            this.BusinessPhone = user.BusinessPhone;
            this.BusinessDeliveryAddress = user.BusinessDeliveryAddress;
            this.BusinessName = user.BusinessName;

            this.BillProvince = user.BillProvince;
            this.BillAddress = user.BillAddress;
            this.BillCountry = user.BillCountry;
            this.BillPostalCode = user.BillPostalCode;

            this.Country = user.Country;
            this.Province = user.Province;
            this.PostalCode = user.PostalCode;

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
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<OrderViewModel> Orders { get; set; }
        public virtual ICollection<ReviewViewModel> Reviews { get; set; }
    }
}
