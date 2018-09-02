using EveMarket.Models;
using EveMarket.Services;
using IO.Swagger.Api;
using IO.Swagger.Client;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EveMarket.Controllers
{
    public class Authentication : Controller
    {
        private readonly IAuthenticationService _authenticationService;

        public Authentication(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index(string code)
        {
            await _authenticationService.LogIn(code);

            return Ok();
        }
    }
}
