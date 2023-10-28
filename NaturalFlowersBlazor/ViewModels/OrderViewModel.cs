using NaturalFlowers.Models;
using System;
using System.Collections.Generic;

namespace NaturalFlowers.ViewModels
{
    public class OrderViewModel
    {
        public OrderViewModel(Order order) 
        {
            this.Id = order.Id;
            this.UserId = order.UserId;
            this.BundleId = order.BundleId;
            this.IsComplete = order.IsComplete;
            this.IsInProgress = order.IsInProgress;
            this.CreatedDate = order.CreatedDate;
        }

        public OrderViewModel()
        {}


        public long? Id { get; set; }
        public string? UserId { get; set; }
        public bool? IsComplete { get; set; }
        public bool? IsInProgress { get; set; }
        public long? BundleId { get; set; }
        public DateTime? CreatedDate { get; set; }

        public BundleViewModel? Bundle { get; set; }
        public UserViewModel? User { get; set; }
    }
}
