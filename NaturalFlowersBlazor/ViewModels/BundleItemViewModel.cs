using NaturalFlowers.Models;
using System;
using System.Collections.Generic;

namespace NaturalFlowers.ViewModels
{
    public partial class BundleItemViewModel
    {
        public long Id { get; set; }
        public long? BundleId { get; set; }
        public long? ItemId { get; set; }
        public int? Amount { get; set; }

        public virtual BundleViewModel? Bundle { get; set; }
        public virtual ItemViewModel? Item { get; set; }
    }
}
