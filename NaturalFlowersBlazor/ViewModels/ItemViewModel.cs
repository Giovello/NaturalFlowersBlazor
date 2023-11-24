using Blazorise;
using NaturalFlowers.Models;
using System;
using System.Collections.Generic;

namespace NaturalFlowers.ViewModels
{
    public partial class ItemViewModel
    {
        public ItemViewModel()
        {
            this.Reviews = new List<ReviewViewModel>();
            this.Quantities = new List<int>();
            this.BulkQuantities = new List<int>();
        }

        public ItemViewModel(Item item)
        {
            this.Description = item.Description;
            this.Reviews = new List<ReviewViewModel>();
            this.Quantities = new List<int>();
            this.BulkQuantities = new List<int>();
            this.Quantities = item.Quantities.Split(',').Select(int.Parse).ToList();
            this.StringQuantities = item.Quantities;
            this.StringBulkQuantities = item.BulkQuantities;

            if(!String.IsNullOrEmpty(item.BulkQuantities))
                this.BulkQuantities = item.BulkQuantities.Split(',').Select(int.Parse).ToList();
            
            this.DetainedStock = item.DetainedStock;
            this.Stock = item.Stock;
            this.Price = Math.Round(item.Price, 2);
            this.Score = item.score;
            this.FriendlyName = item.FriendlyName;
            this.Id = item.Id;
            this.Name = item.Name;
            this.CreatedDate = item.CreatedDate;
            this.StripeId = item.StripeId;
        }
        

        public long Id { get; set; }
        public string StripeId { get; set; }
        public string Name { get; set; } = null!;
        public string FriendlyName { get; set; } = null!;
        public decimal Price { get; set; }
        public int Score { get; set; }
        public int Stock { get; set; }
        public int DetainedStock { get; set; }
        public string Description { get; set; } = null!;
        public List<int>? Quantities { get; set; } = null!;
        public string StringQuantities { get; set; }
        public List<int>? BulkQuantities { get; set; }
        public string? StringBulkQuantities { get; set; }
        public DateTime? CreatedDate { get; set; }
        public List<ReviewViewModel>? Reviews { get; set; }
    }
}
