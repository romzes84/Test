using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ExchangeRates.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ExchangeRates.Models;

namespace ExchangeRates.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ICBR _rateservice;

        public HomeController(ILogger<HomeController> logger,ICBR ratesrv)
        {
            _logger = logger;
            _rateservice = ratesrv;
        }

        public async Task<ActionResult> Index()
        {
            List<Valute> lst = await  _rateservice.GetCourse(DateTime.Now);
            
            ViewData["cource"] = "test";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}