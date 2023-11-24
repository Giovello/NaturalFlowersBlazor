using NaturalFlowers.Models;
using NaturalFlowers.ViewModels;
using System.Text;

namespace NaturalFlowersBlazor.Services
{
    public class StockService : ServiceBase
    {
        public StockService() { }


        public async Task<StockFilterViewModel> GetAllItems(StockFilterViewModel filter)
        {
            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(filter), Encoding.UTF8, "application/json");

            var result = await ApiClient.PutAsync($"stock", content);

            var itemList = await result.Content.ReadFromJsonAsync<StockFilterViewModel>();
            return itemList;
        }

        public async Task<List<ItemViewModel>> GetAllItemsNoFilter()
        {
            var result = await ApiClient.GetAsync($"stock");

            var itemList = await result.Content.ReadFromJsonAsync<List<ItemViewModel>>();
            return itemList;
        }

        public async Task<ItemViewModel> GetSingleItemAsync(int id)
        {
            var result = await ApiClient.GetAsync($"stock/{id}");

            var item = await result.Content.ReadFromJsonAsync<ItemViewModel>();
            return item;
        }

        public async Task AddItemAsync(ItemViewModel item)
        {
            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(item), Encoding.UTF8, "application/json");

            var result = await ApiClient.PostAsync($"stock/add",content);

            return;
        }

        public async Task UpdateItemAsync(ItemViewModel item)
        {
            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(item), Encoding.UTF8, "application/json");

            var result = await ApiClient.PutAsync($"stock/update", content);

            return;
        }

        public async Task DeleteItemAsync(ItemViewModel item)
        {
            var id = item.Id;

            var result = await ApiClient.DeleteAsync($"stock/{id}");

            return;
        }
    }
}
