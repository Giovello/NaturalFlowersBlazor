using Microsoft.AspNetCore.Components.Authorization;
using NaturalFlowers.Models;
using System.Security.Claims;

namespace NaturalFlowersBlazor.Services
{
    public class UserService : ServiceBase, IUserService
    {
        private readonly IHttpContextAccessor _httpContext;

        public UserService(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }


        public async Task<string> GetUserIdAsync()
        {
            return _httpContext.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
