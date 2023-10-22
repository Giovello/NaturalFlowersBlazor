using NaturalFlowers.Models;
using System;
using System.Collections.Generic;

namespace NaturalFlowers.ViewModels
{
    public partial class OrderViewModel
    {
        OrderViewModel(Order order) 
        {
            this.CreatedDate = order.CreatedDate;
            this.UserId = order.UserId;
            this.BundleId = order.BundleId;
            this.IsComplete = order.IsComplete;
        }


        public long Id { get; set; }
        public string UserId { get; set; }
        public bool IsComplete { get; set; }
        public DateTime CreatedDate { get; set; }
        public long BundleId { get; set; }

        public virtual BundleViewModel Bundle { get; set; } = null!;
        public virtual UserViewModel User { get; set; } = null!;
    }
}
