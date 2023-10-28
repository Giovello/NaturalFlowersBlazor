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

        public async Task<OrderViewModel> ConfirmOrderAsync(int id)
        {
            var userId = await _userService.GetUserIdAsync();

            var result = await ApiClient.GetAsync($"order/confirm/{id}");

            var order = await result.Content.ReadFromJsonAsync<OrderViewModel>();

            return order;
        }

        public async Task UpdateUserAddressBeforeOrder(string address, string province, string country, string postalCode, string fullName)
        {
            var userId = await _userService.GetUserIdAsync();

            AddressSubmitViewModel user = new AddressSubmitViewModel();

            user.UserId = userId;
            user.DeliveryAddress = address;
            user.Province = province;
            user.Country = country;
            user.PostalCode = postalCode;
            user.FullName = fullName;

            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");

            var result = await ApiClient.PutAsync($"order/updateAddress", content);

            //var result = await ApiClient.GetAsync($"order/updateAddress");


            return;
        }
        
    }
}
