using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace NaturalFlowers.ViewModels
{
    public partial class AddressSubmitViewModel
    {
        public AddressSubmitViewModel()
        {}

        public string UserId { get; set; }
        public string DeliveryAddress { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; } 
        public string FullName { get; set; }
        
    }
}
