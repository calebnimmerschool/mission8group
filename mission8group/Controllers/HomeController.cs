using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public IActionResult QuadView()
        {
            var tasks = _context.Tasks
                .Include(x => x.Category)  // Include the related Category data
                .OrderBy(x => x.DueDate)  // Order tasks by Due Date (adjust as needed)
                .Select(x => new TimeManagementForm
                {
                    TaskId = x.TaskId,
                    Task = x.Task,
                    DueDate = x.DueDate ?? "",  // Default DateTime.MinValue for NULL DueDate
                    Quadrant = x.Quadrant,
                    Completed = x.Completed,  // Default false for NULL Completed
                    CategoryId = x.CategoryId,  // Handle CategoryId
                    Category = x.Category,  // Include Category details
                })
                .ToList();

            return View(tasks);
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
