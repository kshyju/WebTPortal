using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using WebTPortal.Models;

namespace WebTPortal.Controllers
{
    public class HomeController : Controller
    {
       
        HealthData d=new HealthData();


        public IActionResult Index()
        {
            var calls = d.GetRunsForSite(1);
            var vm = new SiteDetails() {Calls = calls};
            return View(vm);
        }


        public IActionResult RunDetails(int id,string displayType = "all")
        {
            var calls = d.GetCallsForRun(id, 2);
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
            var calls = d.GetCallsForUrl(url);
            return View(calls);
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
