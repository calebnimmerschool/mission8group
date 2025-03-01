using System;

namespace mission8group.Models
{
    public class TimeManagementFormRepository : ITimeManagementFormRepository
    {
        private readonly TimeManagementContext _context;

        public TimeManagementFormRepository(TimeManagementContext context)
        {
            _context = context;
        }

        public IEnumerable<TimeManagementForm> GetAll()
        {
            return _context.Tasks
                .Where(t => !t.Completed)
                .ToList();
        }

        public TimeManagementForm GetById(int id)
        {
            return _context.Tasks.Find(id);
        }

        public void Add(TimeManagementForm task)
        {
            _context.Tasks.Add(task);
            Save();
        }

        public void Update(TimeManagementForm task)
        {
            _context.Tasks.Update(task);
            Save();
        }

        public void Delete(int id)
        {
            var task = GetById(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                Save();
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public IEnumerable<TimeManagementForm> GetIncompleteTasks()
        {
            return _context.Tasks
                .Where(t => !t.Completed)
                .ToList();
        }

        public IEnumerable<TimeManagementForm> GetTasksByQuadrant(int quadrant)
        {
            return _context.Tasks
                .Where(t => !t.Completed && t.Quadrant == quadrant)
                .ToList();
        }
    }
}
