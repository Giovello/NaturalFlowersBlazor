using NaturalFlowers.Models;
using NaturalFlowers.ViewModels;
using System.Text;

namespace NaturalFlowersBlazor.Services
{
    public class AdminService : ServiceBase
    {
        public AdminService() { }


        public async Task<StockFilterViewModel> GetAllItems(StockFilterViewModel filter)
        {
            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(filter), Encoding.UTF8, "application/json");

            var result = await ApiClient.PutAsync($"stock", content);

            var itemList = await result.Content.ReadFromJsonAsync<StockFilterViewModel>();
            return itemList;
        }

        public async Task<ItemViewModel> GetSingleItemAsync(int id)
        {
            var result = await ApiClient.GetAsync($"stock/{id}");

            var item = await result.Content.ReadFromJsonAsync<ItemViewModel>();
            return item;
        }
    }
}
