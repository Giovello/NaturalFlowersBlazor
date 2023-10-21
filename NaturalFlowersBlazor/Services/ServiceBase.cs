using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using static System.Net.WebRequestMethods;

namespace NaturalFlowersBlazor
{
    public class ServiceBase
    {
        public ServiceBase() {
            ApiClient = new HttpClient() {
                BaseAddress = new Uri("https://localhost:7126/")
                //BaseAddress = new Uri("https://naturalflowersas.azurewebsites.net/")
            };
        }

        public HttpClient ApiClient { get; set; }
    }
}
