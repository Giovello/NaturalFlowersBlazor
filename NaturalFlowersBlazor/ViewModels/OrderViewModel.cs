using System;
using System.Collections.Generic;

namespace NaturalFlowers.ViewModels
{
    public partial class OrderViewModel
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public bool IsComplete { get; set; }
        public DateTime CreatedDate { get; set; }
        public long BundleId { get; set; }

        public virtual BundleViewModel Bundle { get; set; } = null!;
        public virtual UserViewModel User { get; set; } = null!;
    }
}
