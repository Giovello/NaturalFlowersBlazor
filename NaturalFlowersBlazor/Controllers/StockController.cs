using Microsoft.AspNetCore.Authorization;
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
    }
}
