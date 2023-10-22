using NaturalFlowers.Models;
using NaturalFlowers.ViewModels;
using System.Text;

namespace NaturalFlowersBlazor.Services
{
    public class StripeService : ServiceBase
    {
        public StripeService() { }


        public async Task<string> CreateCheckout(BundleViewModel bundle, string userId)
        {
            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(bundle), Encoding.UTF8, "application/json");

            var result = await ApiClient.PostAsync($"stripe/createCheckout/{userId}", content);

            var Url = await result.Content.ReadAsStringAsync();

            return Url;
        }

    }
}
