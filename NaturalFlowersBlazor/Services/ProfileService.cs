using NaturalFlowers.Models;
using NaturalFlowers.ViewModels;
using Stripe;
using System.Text;

namespace NaturalFlowersBlazor.Services
{
    public class ProfileService : ServiceBase
    {
        public ProfileService() { }


        public async Task<UserViewModel> GetProfile(string id)
        {
            var result = await ApiClient.GetAsync($"profile/{id}");

            var user = await result.Content.ReadFromJsonAsync<UserViewModel>();
            return user;
        }

        public async Task UpdateProfile(UserViewModel item)
        {
            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(item), Encoding.UTF8, "application/json");

            var result = await ApiClient.PutAsJsonAsync($"profile",item);

            return;
        }

        public async Task SendApplication(UserViewModel item)
        {
            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(item), Encoding.UTF8, "application/json");

            var result = await ApiClient.PutAsJsonAsync($"profile/apply", item);

            return;
        }
    }
}
