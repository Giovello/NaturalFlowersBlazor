using NaturalFlowers.Models;
using System;
using System.Collections.Generic;

namespace NaturalFlowers.ViewModels
{
    public partial class ReviewViewModel
    {
        public ReviewViewModel()
        {
        }

        public ReviewViewModel(Review review)
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
    }
}
