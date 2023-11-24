using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NaturalFlowers.Models;
using NaturalFlowers.ViewModels;
using NaturalFlowersBlazor.Data;

namespace NaturalFlowersBlazor.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("[controller]")]
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProfileController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public ActionResult GetProfile(string id)
        {
            var item = _context.Users.Single(use => use.Id == id);
            UserViewModel userViewModel = new UserViewModel(item);

            
            return Ok(userViewModel);
        }

        [HttpPut()]
        public async Task<ActionResult> UpdateProfile([FromBody] User user)
        {
            var item = _context.Users.Single(use => use.Id == user.Id);

            item.Id = user.Id;
            item.Email = user.Email;
            item.FullName = user.FullName;
            item.DeliveryAddress = user.DeliveryAddress;
            item.IsAdmin = user.IsAdmin;
            item.IsBulkBuyer = user.IsBulkBuyer;

            item.BusinessAddress = user.BusinessAddress;
            item.BusinessPhone = user.BusinessPhone;
            item.BusinessDeliveryAddress = user.BusinessDeliveryAddress;
            item.BusinessName = user.BusinessName;

            item.BillProvince = user.BillProvince;
            item.BillAddress = user.BillAddress;
            item.BillCountry = user.BillCountry;
            item.BillPostalCode = user.BillPostalCode;

            item.Country = user.Country;
            item.Province = user.Province;
            item.PostalCode = user.PostalCode;

            _context.Update(item);

            await _context.SaveChangesAsync();


            return Ok();
        }

        [HttpPut("apply")]
        public async Task<ActionResult> ApplyForBulkBuyerStatus([FromBody] User user)
        {
            var item = _context.Users.Single(use => use.Id == user.Id);

            item.BusinessAddress = user.BusinessAddress;
            item.BusinessPhone = user.BusinessPhone;
            item.BusinessDeliveryAddress = user.BusinessDeliveryAddress;
            item.BusinessName = user.BusinessName;

            _context.Update(item);

            await _context.SaveChangesAsync();


            return Ok();
        }
    }
}
