using System.ComponentModel.DataAnnotations;

namespace mission8group.Models;

public class Category
{
    [Key]
    public int CategoryId { get; set; }
    public string Name { get; set; }
}