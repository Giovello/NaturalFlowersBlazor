using System;
using System.Collections.Generic;

namespace NaturalFlowers.Models
{
    public partial class Item
    {
        public Item()
        {
            BundleItems = new List<BundleItem>();
            Reviews = new List<Review>();
        }

        public long Id { get; set; }
        public string StripeId { get; set; }
        public string Name { get; set; } = null!;
        public string FriendlyName { get; set; } = null!;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int DetainedStock { get; set; }
        public string Description { get; set; } = null!;
        public int score { get; set; }
        public string Quantities { get; set; } = null!;
        public string? BulkQuantities { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<BundleItem> BundleItems { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
