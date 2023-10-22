using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NaturalFlowers.Models;
using NaturalFlowers.ViewModels;
using NaturalFlowersBlazor.Data;
using NaturalFlowersBlazor.Services;
using System;

namespace NaturalFlowersBlazor.Controllers
{   
    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserService _userSvc;

        private readonly UserManager<User> _userManager;

        public OrderController(ApplicationDbContext context, IUserService userSvc, UserManager<User> userManager)
        {
            _context = context;
            _userSvc = userSvc;
            _userManager = userManager;
        }

        /// <summary>
        /// Gets the current user's active order bundle.
        /// </summary>
        /// <returns></returns>
        [HttpGet("{userId}")]
        public async Task<ActionResult> GetUserBundle(string userId)
        {
            Order order = _context.Orders.Where(ord => ord.UserId == userId && ord.IsComplete == false).FirstOrDefault();

            if (order == null)
            {
                order = new Order();
                order.UserId = userId;
                order.Bundle = new Bundle();

                await _context.Bundles.AddAsync(order.Bundle);

                await _context.SaveChangesAsync();

                order.IsComplete = false;
                order.BundleId = order.Bundle.Id;

                await _context.Orders.AddAsync(order);

                await _context.SaveChangesAsync();
            }

            Bundle bundle = _context.Bundles.FirstOrDefault(bund => order.BundleId == bund.Id);

            List<BundleItem> bundleItems = _context.BundleItems.Where(bundIt => bundIt.BundleId == bundle.Id).ToList();

            BundleViewModel bundleViewModel = new BundleViewModel(bundle);

            List<Item> items = _context.Items.ToList();

            foreach (BundleItem bi in bundleItems)
            {
                BundleItemViewModel bundleItemViewModel = new BundleItemViewModel(bi);

                bundleItemViewModel.Item = new ItemViewModel(items.FirstOrDefault(it => bi.ItemId == it.Id));

                bundleViewModel.BundleItems.Add(bundleItemViewModel);
            }


            return Ok(bundleViewModel);
        }

        [HttpPost("{quantity}/{userId}")]
        public async Task<ActionResult> AddItemToOrderBundle([FromBody] ItemViewModel item, int quantity, string userId)
        {

            Order order = _context.Orders.Where(ord => ord.UserId == userId && ord.IsComplete == false).FirstOrDefault();

            if (order == null)
            {
                order = new Order();
                order.UserId = userId;
                order.Bundle = new Bundle();

                await _context.Bundles.AddAsync(order.Bundle);

                await _context.SaveChangesAsync();

                order.IsComplete = false;
                order.BundleId = order.Bundle.Id;

                await _context.Orders.AddAsync(order);

                await _context.SaveChangesAsync();
            }

            Bundle bundle = _context.Bundles.FirstOrDefault(bund => order.BundleId == bund.Id);

            BundleItem bundleItem = _context.BundleItems.Where(bundIt => bundIt.BundleId == bundle.Id && bundIt.ItemId == item.Id).FirstOrDefault();

            if (bundleItem == null)
            {
                bundleItem = new BundleItem();
                bundleItem.ItemId = item.Id;
                bundleItem.BundleId = bundle.Id;
                bundleItem.Amount = quantity;

                await _context.BundleItems.AddAsync(bundleItem);
            } else
            {
                bundleItem.Amount += quantity;
            }

            await _context.SaveChangesAsync();

            List<BundleItem> bundleItems = _context.BundleItems.Where(bundIt => bundIt.BundleId == bundle.Id).ToList();

            BundleViewModel bundleViewModel = new BundleViewModel(bundle);

            List<Item> items = _context.Items.ToList();

            foreach (BundleItem bi in bundleItems)
            {
                BundleItemViewModel bundleItemViewModel = new BundleItemViewModel(bi);

                bundleItemViewModel.Item = new ItemViewModel(items.FirstOrDefault(it => bi.ItemId == it.Id));

                bundleViewModel.BundleItems.Add(bundleItemViewModel);
            }

            return Ok(bundleViewModel);
        }

        [HttpPut("remove/{userId}")]
        public async Task<ActionResult> RemoveItemFromOrderBundle([FromBody] ItemViewModel item, string userId)
        {

            Order order = _context.Orders.Where(ord => ord.UserId == userId && ord.IsComplete == false).FirstOrDefault();

            Bundle bundle = _context.Bundles.FirstOrDefault(bund => order.BundleId == bund.Id);

            BundleItem bundleItem = _context.BundleItems.Where(bundIt => bundIt.BundleId == bundle.Id && bundIt.ItemId == item.Id).FirstOrDefault();

            bundleItem.Amount -= 1;

            if(bundleItem.Amount <= 0)
            {
                _context.BundleItems.Remove(bundleItem);
            }

            await _context.SaveChangesAsync();

            List<BundleItem> bundleItems = _context.BundleItems.Where(bundIt => bundIt.BundleId == bundle.Id).ToList();

            BundleViewModel bundleViewModel = new BundleViewModel(bundle);

            List<Item> items = _context.Items.ToList();

            foreach (BundleItem bi in bundleItems)
            {
                BundleItemViewModel bundleItemViewModel = new BundleItemViewModel(bi);

                bundleItemViewModel.Item = new ItemViewModel(items.FirstOrDefault(it => bi.ItemId == it.Id));

                bundleViewModel.BundleItems.Add(bundleItemViewModel);
            }

            return Ok(bundleViewModel);
        }
    }
}
