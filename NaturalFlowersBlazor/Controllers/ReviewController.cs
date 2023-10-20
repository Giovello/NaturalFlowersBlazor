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
    public class ReviewController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReviewController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet()]
        public ActionResult GetAllReviews()
        {
            var reviews = _context.Reviews;
            List<ReviewViewModel> allMappedReviews = new List<ReviewViewModel>();

            foreach (var review in reviews)
            {
                ReviewViewModel reviewViewModel = new ReviewViewModel(review);

                
                allMappedReviews.Add(reviewViewModel);
            }

            return Ok(allMappedReviews);
        }

        [HttpPost()]
        public async Task<ActionResult> PostReview([FromBody] ReviewViewModel reviewViewModel)
        {
            Review reviewToPost = new Review(reviewViewModel);

            _context.Reviews.Add(reviewToPost);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
