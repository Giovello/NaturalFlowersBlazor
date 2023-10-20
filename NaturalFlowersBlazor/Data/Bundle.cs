using System;
using System.Collections.Generic;

namespace NaturalFlowers.Models
{
    public partial class Bundle
    {
        public Bundle()
        {
            BundleItems = new List<BundleItem>();
            Orders = new List<Order>();
        }

        public long Id { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<BundleItem> BundleItems { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
