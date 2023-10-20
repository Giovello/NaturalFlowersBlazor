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
            Reviews = new List<ReviewViewModel>();
            Quantities = new List<int>();
            BulkQuantities = new List<int>();  
    }

        public ItemViewModel(Item item)
        {
            this.Description = item.Description;
            this.Reviews = new List<ReviewViewModel>();
            this.Quantities = item.Quantities.Split(',').Select(int.Parse).ToList();

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
        }
        

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string FriendlyName { get; set; } = null!;
        public decimal Price { get; set; }
        public int Score { get; set; }
        public int Stock { get; set; }
        public int DetainedStock { get; set; }
        public string Description { get; set; } = null!;
        public List<int> Quantities { get; set; } = null!;
        public List<int>? BulkQuantities { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<ReviewViewModel> Reviews { get; set; }
    }
}
