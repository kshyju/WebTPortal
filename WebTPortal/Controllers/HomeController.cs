using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebTPortal.Data;
using WebTPortal.Models;

namespace WebTPortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHealthData db;

        public HomeController(IHealthData healthData)
        {
            this.db = healthData;
        }

        public IActionResult Index()
        {
            var calls = db.GetRunsForSite(1);
            var vm = new SiteDetails() {Calls = calls};
            return View(vm);
        }


        public IActionResult RunDetails(int id,string displayType = "all")
        {
            var calls = db.GetCallsForRun(id, 2);
            var vm = new RunDetailsVm
            {
                DisplayType= displayType,
                Calls = calls,
                RunId = id,
                StartTime = calls.First().StartTime
            };
            return View(vm);
        }
        public IActionResult DetailsForUrl(string url)
        {
            var vm = new UrlRunDetails
            {
                Calls = db.GetCallsForUrl(url),
                Url = url
            };
            return View(vm);
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
