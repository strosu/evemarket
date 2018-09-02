using EveMarket.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EveMarket.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Redirect("https://login.eveonline.com/oauth/authorize/?response_type=code&redirect_uri=https%3A%2F%2Flocalhost%3A44324%2FAuthentication&client_id=2590e8414d08467693e11d5e9ca22248&scope=esi-markets.structure_markets.v1%20esi-characters.read_blueprints.v1&state=uniquestate123");
            // return Ok();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Login()
        {
            return Redirect("https://login.eveonline.com/oauth/authorize/?response_type=code&redirect_uri=https%3A%2F%2Flocalhost%3A44324%2FAuthentication&client_id=2590e8414d08467693e11d5e9ca22248&scope=esi-markets.structure_markets.v1%20esi-characters.read_blueprints.v1&state=uniquestate123");
        }

        public IActionResult callback()
        {
            return Ok();
        }
    }
}
