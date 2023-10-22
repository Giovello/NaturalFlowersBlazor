using NaturalFlowers.Models;
using System;
using System.Collections.Generic;

namespace NaturalFlowers.ViewModels
{
    public partial class BundleItemViewModel
    {
        public BundleItemViewModel()
        {
        }

        public BundleItemViewModel(BundleItem bundleItem) 
        { 
            this.Id = bundleItem.Id;
            this.BundleId = bundleItem.BundleId;
            this.ItemId = bundleItem.ItemId;
            this.Amount = bundleItem.Amount;
        }

        public long Id { get; set; }
        public long? BundleId { get; set; }
        public long? ItemId { get; set; }
        public int? Amount { get; set; }

        //public virtual BundleViewModel? Bundle { get; set; }
        public virtual ItemViewModel? Item { get; set; }
    }
}
