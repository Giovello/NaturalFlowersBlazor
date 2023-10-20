using System;
using System.Collections.Generic;

namespace NaturalFlowers.Models
{
    public partial class BundleItem
    {
        public long Id { get; set; }
        public long? BundleId { get; set; }
        public long? ItemId { get; set; }
        public int? Amount { get; set; }

        public virtual Bundle? Bundle { get; set; }
        public virtual Item? Item { get; set; }
    }
}
