using System;
using System.Collections.Generic;

namespace NaturalFlowers.Models
{
    public partial class Order
    {
        public long Id { get; set; }
        public string UserId { get; set; }
        public bool IsComplete { get; set; } = false;
        public bool IsInProgress { get; set; } = false;
        public DateTime CreatedDate { get; set; }
        public long BundleId { get; set; }

        public virtual Bundle Bundle { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
