using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NaturalFlowers.Models;
using NaturalFlowers.ViewModels;
using NaturalFlowersBlazor.Data;
using Stripe;
using Stripe.Checkout;

namespace NaturalFlowersBlazor.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("[controller]")]
    public class StripeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StripeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("createCheckout/{userId}")]
        public ActionResult Create([FromBody] BundleViewModel bundle, string userId)
        {
            var userEmail = _context.Users.FirstOrDefault(user => user.Id == userId).Email;
           

            var domain = "https://naturalflowersas.azurewebsites.net/";

            var LineItems = new List<SessionLineItemOptions>();
                
            foreach(BundleItemViewModel item in bundle.BundleItems)
            {
                var itemOptions = new SessionLineItemOptions();
                itemOptions.Price = item.Item.StripeId;
                itemOptions.Quantity = item.Amount;

                LineItems.Add(itemOptions);
            }

            var options = new SessionCreateOptions
            {
                Mode = "payment",
                SuccessUrl = domain + $"success/{bundle.Id}",
                CancelUrl = domain + "cancel",
                AutomaticTax = new SessionAutomaticTaxOptions { Enabled = true },
            };

            options.LineItems = LineItems;
            options.CustomerEmail = userEmail;

            var service = new SessionService();
            Session session = service.Create(options);

            Response.Headers.Add("Location", session.Url);
            return Ok(session.Url);
        }
    }
}
