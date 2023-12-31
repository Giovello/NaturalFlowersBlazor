﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NaturalFlowers.Models;
using NaturalFlowers.ViewModels;
using NaturalFlowersBlazor.Data;

namespace NaturalFlowersBlazor.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("[controller]")]
    public class StockController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StockController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPut()]
        public async Task<ActionResult> GetAllItems([FromBody] StockFilterViewModel filter)
        {
            var items = _context.Items.ToList();

            List<ItemViewModel> allMappedItems = new List<ItemViewModel>();

            foreach (var item in items)
            {
                ItemViewModel itemViewModel = new ItemViewModel(item);

                List<Review> reviews = _context.Reviews.Where(rev => rev.ItemId == item.Id).ToList();            
                int reviewsCount = reviews.Count();

                if (reviewsCount != 0)
                {
                    int reviewScoreUndivided = 0;

                    foreach (Review review in reviews)
                    {
                        reviewScoreUndivided += review.Rating;
                    }

                    itemViewModel.Score = reviewScoreUndivided / reviewsCount;
                }

                allMappedItems.Add(itemViewModel);
            }

            List<ItemViewModel> filteredItems = allMappedItems;

            if (filter.SearchText != null)
            {
                filteredItems = filteredItems.Where(item => item.Name.ToLower().Contains(filter.SearchText.ToLower())).ToList();
            }

            if (filter.MaxPrice != null)
            {
                filteredItems = filteredItems.Where(item => item.Price <= filter.MaxPrice).ToList();
            }

            if (filter.NumStars != null)
            {
                filteredItems = filteredItems.Where(item => item.Score > filter.NumStars).ToList();
            }




            StockFilterViewModel newFilter = new StockFilterViewModel();
            // handle paging
            if (filter.PageStartIndex > 0 || filter.PageCount > 0) newFilter.Items = filteredItems.Skip(filter.PageStartIndex).Take(filter.PageCount).ToList();
            else newFilter.Items = filteredItems.ToList();
            newFilter.PageOffset = filter.PageStartIndex;
            newFilter.PageCount = filteredItems.Count;
            newFilter.TotalItemsCount = items.Count();

            return Ok(newFilter);
        }

        [HttpGet()]
        public async Task<ActionResult> GetAllItemsNoFilter()
        {
            var items = _context.Items.ToList();

            List<ItemViewModel> allMappedItems = new List<ItemViewModel>();

            foreach (var item in items)
            {
                ItemViewModel itemViewModel = new ItemViewModel(item);


                allMappedItems.Add(itemViewModel);
            }

            return Ok(allMappedItems);
        }

        [HttpGet("{id}")]
        public ActionResult GetSingleItems(int id)
        {
            var item = _context.Items.Where(it => it.Id == id).ToList();
            ItemViewModel itemViewModel = new ItemViewModel(item.First());

            List<Review> reviews = _context.Reviews.Where(rev => rev.ItemId == id).ToList();
            int reviewsCount = reviews.Count();
            List<ReviewViewModel> mappedReviews = new List<ReviewViewModel>();

            if (reviewsCount != 0)
            {
                int reviewScoreUndivided = 0;

                foreach (Review review in reviews)
                {
                    reviewScoreUndivided += review.Rating;

                    ReviewViewModel reviewViewModel = new ReviewViewModel(review);
                    mappedReviews.Add(reviewViewModel);
                }

                itemViewModel.Reviews = mappedReviews;
                itemViewModel.Score = reviewScoreUndivided / reviewsCount;
            }
            return Ok(itemViewModel);
        }

        [HttpPost("add")]
        public async Task<ActionResult> AddItem([FromBody] ItemViewModel itemToAdd)
        {
            itemToAdd.DetainedStock = 0;

            Item item = new Item();

            item.BulkQuantities = itemToAdd.StringBulkQuantities;
            item.Id = itemToAdd.Id;
            item.Name = itemToAdd.Name;
            item.Description = itemToAdd.Description;
            item.Price = itemToAdd.Price;
            item.Stock = itemToAdd.Stock;
            item.Quantities = itemToAdd.StringQuantities;
            item.DetainedStock = itemToAdd.DetainedStock;
            item.FriendlyName = itemToAdd.FriendlyName;
            item.score = itemToAdd.Score;
            item.StripeId = itemToAdd.StripeId;

            await _context.Items.AddAsync(item);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("update")]
        public async Task<ActionResult> UpdateItem([FromBody] ItemViewModel itemToUpdate)
        {
            var item = _context.Items.Where(it => it.Id == itemToUpdate.Id).Single();

            item.BulkQuantities = itemToUpdate.StringBulkQuantities;
            item.Quantities = itemToUpdate.StringQuantities;
            item.FriendlyName = itemToUpdate.FriendlyName;
            item.Name = itemToUpdate.Name;
            item.Description = itemToUpdate.Description;
            item.DetainedStock = itemToUpdate.DetainedStock;
            item.Price = itemToUpdate.Price;
            item.StripeId = itemToUpdate.StripeId;
            item.Stock = itemToUpdate.Stock;
            item.score = itemToUpdate.Score;

            _context.Items.Update(item);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItem(int id)
        {
            var item = _context.Items.Where(it => it.Id == id).Single();

            _context.Items.Remove(item);
            await _context.SaveChangesAsync();


            return Ok();
        }
    }
}
