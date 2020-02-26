using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Premium.Models;

namespace Premium.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private List<PremiumCondition> _conditions = new List<PremiumCondition>();

        private CultureInfo _ci;

        public HomeController(ILogger<HomeController> logger)
        {
            _ci = new CultureInfo("en-US");
            _logger = logger;
            _conditions = new List<PremiumCondition>(){
                new PremiumCondition { State = "NY", Month = "August",      Left = 18, Right = 45, Premium = 150 },
                new PremiumCondition { State = "NY", Month = "January",     Left = 46, Right = 65, Premium = 200.50 },
                new PremiumCondition { State = "NY", Month = "*",           Left = 18, Right = 65, Premium = 120.99 },
                new PremiumCondition { State = "AL", Month = "November",    Left = 18, Right = 65, Premium = 85.50 },
                new PremiumCondition { State = "AL", Month = "*",           Left = 18, Right = 65, Premium = 100 },
                new PremiumCondition { State = "AK", Month = "December",    Left = 65, Right = -1, Premium = 175.20 },
                new PremiumCondition { State = "AK", Month = "December",    Left = 18, Right = 64, Premium = 125.16 },
                new PremiumCondition { State = "AK", Month = "*",           Left = 18, Right = 65, Premium = 100.80 },
                new PremiumCondition { State = "*",  Month = "*",           Left = 18, Right = 65, Premium = 90 },
            };
        }

        public IActionResult Index()
        {
            return View();
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

        public JsonResult Premium(DateTime dateOfBirth, string state, int age)
        {
            string month = dateOfBirth.ToString("MMMM", _ci);

            var res = _conditions.Where(row => row.State == state
                                                && (row.Month == month || (row.Month != month && row.Month == "*"))
                                                && (age >= row.Left && (age <= row.Right || row.Right == -1))
                                                );            
            return Json(new { 
                premium = res.Count() > 0 ? res.First().Premium : -1
            });
        }
    }
}
