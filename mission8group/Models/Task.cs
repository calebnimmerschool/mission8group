using System;
using System.ComponentModel.DataAnnotations;

namespace mission8group.Models
{
    public class Task
    {
        // Primary key for the Task
        public int TaskId { get; set; }

        // Task title, this is a required field
        [Required]
        [StringLength(100)]  // Limiting the length of the title to 100 characters
        public string Title { get; set; }

        // Due date of the task (optional field)
        public DateTime? DueDate { get; set; }

        // Quadrant the task belongs to (required field)
        [Required]
        public int Quadrant { get; set; }

        // Category (e.g., Home, School, Work, Church)
        public string? Category { get; set; }

        // Completed status of the task (True or False)
        public bool Completed { get; set; }

        // Constructor (optional, but can be helpful)
        public Task()
        {
            // Default to false when a task is created (not completed)
            Completed = false;
        }
    }
}
