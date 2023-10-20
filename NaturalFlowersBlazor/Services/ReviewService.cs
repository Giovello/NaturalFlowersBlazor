using NaturalFlowers.Models;
using NaturalFlowers.ViewModels;
using System.Text;

namespace NaturalFlowersBlazor.Services
{
    public class ReviewService : ServiceBase
    {
        public ReviewService() { }


        public async Task<List<ReviewViewModel>> GetAllReviews()
        {
            var result = await ApiClient.GetAsync($"review");

            var reviewList = await result.Content.ReadFromJsonAsync<List<ReviewViewModel>>();

            return reviewList;
        }

        public async Task PostReviewAsync(ReviewViewModel review)
        {
            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(review), Encoding.UTF8, "application/json");

            var result = await ApiClient.PostAsync($"review", content);

            return;
        }
    }
}
