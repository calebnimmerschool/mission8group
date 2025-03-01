using System;

namespace mission8group.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly TimeManagementContext _context;

        public CategoryRepository(TimeManagementContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public Category GetById(int id)
        {
            return _context.Categories.Find(id);
        }

        public void Add(Category category)
        {
            _context.Categories.Add(category);
            Save();
        }

        public void Update(Category category)
        {
            _context.Categories.Update(category);
            Save();
        }

        public void Delete(int id)
        {
            var category = GetById(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                Save();
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
