using NaturalFlowers.Models;
using NaturalFlowers.ViewModels;
using System.Text;

namespace NaturalFlowersBlazor.Services
{
    public class OrderService : ServiceBase
    {
        private readonly IUserService _userService;

        public OrderService(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<BundleViewModel> GetOrderBundle()
        {
            var userId = await _userService.GetUserIdAsync();

            var result = await ApiClient.GetAsync($"order/{userId}");

            var bundle = await result.Content.ReadFromJsonAsync<BundleViewModel>();

            return bundle;
        }

        public async Task<BundleViewModel> AddItemToOrderBundle(ItemViewModel item, int quantity)
        {
            var userId = await _userService.GetUserIdAsync();

            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(item), Encoding.UTF8, "application/json");

            var result = await ApiClient.PostAsync($"order/{quantity}/{userId}", content);

            BundleViewModel bundleItem = await result.Content.ReadFromJsonAsync<BundleViewModel>();

            return bundleItem;
        }

        public async Task<BundleViewModel> RemoveItemFromOrderBundle(ItemViewModel item)
        {
            var userId = await _userService.GetUserIdAsync();

            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(item), Encoding.UTF8, "application/json");

            var result = await ApiClient.PutAsync($"order/remove/{userId}", content);

            BundleViewModel bundleItem = await result.Content.ReadFromJsonAsync<BundleViewModel>();

            return bundleItem;
        }
    }
}
