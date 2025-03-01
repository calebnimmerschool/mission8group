using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mission8group.Models;

namespace mission8group.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITimeManagementFormRepository _taskRepo;
        private readonly IRepository<Category> _categoryRepo;

        public HomeController(ITimeManagementFormRepository taskRepo, IRepository<Category> categoryRepo)
        {
            _taskRepo = taskRepo;
            _categoryRepo = categoryRepo;
        }

        public IActionResult Index()
        {
            var tasks = _taskRepo.GetIncompleteTasks();
            return View(tasks);
        }

        public IActionResult AddTask()
        {
            ViewBag.Categories = _categoryRepo.GetAll().ToList();
            return View();
        }

        [HttpPost]
        public IActionResult AddTask(TimeManagementForm task)
        {
            if (ModelState.IsValid)
            {
                _taskRepo.Add(task);
                return RedirectToAction("Index");
            }
            ViewBag.Categories = _categoryRepo.GetAll().ToList();
            return View(task);
        }

        public IActionResult Edit(int id)
        {
            var task = _taskRepo.GetById(id);
            if (task == null) return NotFound();

            ViewBag.Categories = _categoryRepo.GetAll().ToList();
            return View(task);
        }

        [HttpPost]
        public IActionResult Edit(TimeManagementForm task)
        {
            if (ModelState.IsValid)
            {
                _taskRepo.Update(task);
                return RedirectToAction("Index");
            }
            ViewBag.Categories = _categoryRepo.GetAll().ToList();
            return View(task);
        }

        public IActionResult Delete(int id)
        {
            var task = _taskRepo.GetById(id);
            if (task == null) return NotFound();

            return View(task);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _taskRepo.Delete(id);
            return RedirectToAction("Index");
        }

        //[HttpPost]
        //public IActionResult MarkCompleted(int id)
        //{
        //    var task = _taskRepo.GetById(id);
        //    if (task != null)
        //    {
        //        task.Completed = true;
        //        _taskRepo.Update(task);
        //    }
        //    return RedirectToAction("Index");
        //}
    }


}

