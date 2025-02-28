using Microsoft.AspNetCore.Mvc;
using mission8group.Models;  // Namespace for Task model
using System.Linq;
using Microsoft.EntityFrameworkCore; // For LINQ queries

namespace TaskManagerApp.Controllers
{
    public class TasksController : Controller
    {
        private readonly DbContext _context;

        // Injecting the DbContext directly
        public TasksController(DbContext context)
        {
            _context = context;
        }

        // Quadrants View: Displays tasks, sorted into quadrants and incomplete
        public IActionResult Quadrants()
        {
            // Fetching tasks that are not completed
            var tasks = _context.Tasks
                                 .Where(t => !t.Completed)  // Only incomplete tasks
                                 .OrderBy(t => t.DueDate)   // Optional: Sort tasks by due date
                                 .ToList();

            return View(tasks);
        }

        // Edit Task: Displays the edit view
        public IActionResult Edit(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // Update Task: Saves changes after editing
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Task task)
        {
            if (id != task.TaskId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(task);
                _context.SaveChanges();
                return RedirectToAction(nameof(Quadrants));
            }

            return View(task);
        }

        // Mark as Completed: Marks the task as completed
        [HttpPost]
        public IActionResult Complete(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task == null)
            {
                return NotFound();
            }

            task.Completed = true;
            _context.Update(task);
            _context.SaveChanges();

            return RedirectToAction(nameof(Quadrants));
        }

        // Delete Task: Shows the delete confirmation view
        public IActionResult Delete(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // Delete Task: Actually deletes the task from the database
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var task = _context.Tasks.Find(id);
            _context.Tasks.Remove(task);
            _context.SaveChanges();

            return RedirectToAction(nameof(Quadrants));
        }
    }
}
