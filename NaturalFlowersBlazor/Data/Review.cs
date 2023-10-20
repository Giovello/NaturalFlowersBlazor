using NaturalFlowers.ViewModels;
using System;
using System.Collections.Generic;

namespace NaturalFlowers.Models
{
    public partial class Review
    {
        public Review()
        {
        }

        public Review(ReviewViewModel review)
        {
            this.Id = review.Id;
            this.Comment = review.Comment;
            this.Rating = review.Rating;
            this.UserId = review.UserId;
            this.ItemId = review.ItemId;

        }
        public long Id { get; set; }
        public string Comment { get; set; } = null!;
        public int Rating { get; set; }
        public string UserId { get; set; }
        public long ItemId { get; set; }

        public virtual Item Item { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
