using NaturalFlowers.Models;
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

        public BundleViewModel(Bundle bundle)
        {
            this.Id = bundle.Id;


            BundleItems = new List<BundleItemViewModel>();
            Orders = new List<OrderViewModel>();
        }

        

        public long Id { get; set; }

        public virtual List<BundleItemViewModel> BundleItems { get; set; }
        public virtual List<OrderViewModel> Orders { get; set; }
    }
}
