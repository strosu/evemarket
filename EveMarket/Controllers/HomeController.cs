using EveMarket.Models;
using EveMarket.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace EveMarket.Controllers
{
    public class HomeController : Controller
    {
        private const string CookieName = "EveMarketCookie";
        private readonly IAuthenticationService _authenticationService;

        public HomeController(IAuthenticationService authenticationService)
        {
            this._authenticationService = authenticationService;
        }

        public IActionResult Index()
        {
            var cookie = Request.Cookies[CookieName];

            if (cookie == null || !_authenticationService.CheckCookie())
            {

            }

            return Ok();
        }

        public IActionResult Login()
        {
            // Login whe no token is present
            return Redirect("https://login.eveonline.com/oauth/authorize/?response_type=code&redirect_uri=https%3A%2F%2Flocalhost%3A44324%2FAuthentication&client_id=2590e8414d08467693e11d5e9ca22248&scope=esi-markets.structure_markets.v1%20esi-characters.read_blueprints.v1&state=uniquestate123");
        }

        public async Task<IActionResult> LoginWithToken()
        {
            // return when we have a token already
            await _authenticationService.LogIn();
            return Ok();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
