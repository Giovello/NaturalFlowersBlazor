using NaturalFlowers.Models;
using System;
using System.Collections.Generic;

namespace NaturalFlowers.ViewModels
{
    public partial class StockFilterViewModel
    {
        public StockFilterViewModel()
        {
            this.Items = new List<ItemViewModel>();
        }

        public List<ItemViewModel>? Items { get; set; }

        public string? SearchText { get; set; }
        /// <summary>
        /// The number of stars (and above) all returned results should have. 
        /// If an item has less than this many stars, it will not be retrieved.
        /// </summary>
        public long? NumStars { get; set; }  
        public decimal? MaxPrice { get; set; }
        public int PageStartIndex { get; set; } = 0;
        /// <summary>
        /// Number of items to be shown on the page
        /// </summary>
        public int PageCount { get; set; } = 0;
        /// <summary>
        /// Number of total items in the entire collection being retrieved from
        /// </summary>
        public int TotalItemsCount { get; set; } = 0;
        public int PageOffset { get; set; } = 0;
    }
}

