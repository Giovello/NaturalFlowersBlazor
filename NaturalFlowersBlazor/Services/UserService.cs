using Microsoft.AspNetCore.Components.Authorization;
using NaturalFlowers.Models;
using System.Security.Claims;

namespace NaturalFlowersBlazor.Services
{
    public class UserService : ServiceBase, IUserService
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly AuthenticationStateProvider _GetAuthenticationStateAsync;


        public UserService(IHttpContextAccessor httpContext, AuthenticationStateProvider GetAuthenticationStateAsync)
        {
            _httpContext = httpContext;
            _GetAuthenticationStateAsync = GetAuthenticationStateAsync;
        }


        public async Task<string> GetUserIdAsync()
        {
            var authstate = await _GetAuthenticationStateAsync.GetAuthenticationStateAsync();
            return authstate.User.Claims.First().Value;

            //return _httpContext.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
