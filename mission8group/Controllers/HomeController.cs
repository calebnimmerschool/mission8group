using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mission8group.Models;

namespace mission8group.Controllers
{
    public class HomeController : Controller
    {
        private TimeManagementContext _context;
        public HomeController(TimeManagementContext temp)
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddTask()
        {
            ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryName).ToList();

            return View();
        }
        [HttpPost]
        public IActionResult AddTask(TimeManagementForm response)
        {

            _context.Tasks.Add(response); //Add record to the database
            _context.SaveChanges();


            return View("index");


        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
