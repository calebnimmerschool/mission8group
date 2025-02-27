using System.ComponentModel.DataAnnotations;
   using System.ComponentModel.DataAnnotations.Schema;

namespace mission8group.Models;

public class TimeManagementForm
{
   [Key] public int TaskId { get; set; } 
   
   [Required]
   public string Task { get; set; }
   
   public string DueDate { get; set; }
   
   [Required]
   public int Quadrant { get; set; }
   
   [ForeignKey("CategoryId")]
   public int? CategoryId { get; set; }
   public Category? Category { get; set; }
   
   public bool Completed { get; set; }
   
}