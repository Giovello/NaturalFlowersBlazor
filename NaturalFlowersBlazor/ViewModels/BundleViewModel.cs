using NaturalFlowers.ViewModels;
using System;
using System.Collections.Generic;

namespace NaturalFlowers.ViewModels
{
    public partial class BundleViewModel
    {
        public BundleViewModel()
        {
            BundleItems = new List<BundleItemViewModel>();
            Orders = new List<OrderViewModel>();
        }

        public long Id { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<BundleItemViewModel> BundleItems { get; set; }
        public virtual ICollection<OrderViewModel> Orders { get; set; }
    }
}
