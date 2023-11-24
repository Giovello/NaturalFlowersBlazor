using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using NaturalFlowers.Models;
using System.Security.Claims;

namespace NaturalFlowersBlazor.Services
{
    public class UserService : ServiceBase, IUserService
    {
        private readonly IHttpContextAccessor _httpContext;
        [Inject]
        private AuthenticationStateProvider _AuthProvider { get; set; }
        public UserService(IHttpContextAccessor httpContext, AuthenticationStateProvider AuthProvider)
        {
            _httpContext = httpContext;
            _AuthProvider = AuthProvider;
        }


        public async Task<string> GetUserIdAsync()
        {
            //return _httpContext.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            var authstate = await _AuthProvider.GetAuthenticationStateAsync();
            //this.loginId = authstate.User.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;

            return authstate.User.Claims.First().Value;
        }
    }
}
