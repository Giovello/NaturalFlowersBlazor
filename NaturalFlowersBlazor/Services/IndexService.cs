using NaturalFlowers.Models;

namespace NaturalFlowersBlazor.Services
{
    public class IndexService : ServiceBase
    {
        public IndexService() { }


        public async Task<List<Item>> GetPopularItemsAsync()
        {
            var result = await ApiClient.GetAsync($"index");

            var itemList = await result.Content.ReadFromJsonAsync<List<Item>>();
            return itemList;
        }
    }
}
