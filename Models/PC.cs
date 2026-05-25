using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_TASK_7.Models;

[Table("PCs")]
public class PC
{
    [Key]
    public int Id { get; set; } // int PK

    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = null!; 

    [Required]
    public double Weight { get; set; } 

    [Required]
    public int Warranty { get; set; } 

    [Required]
    public DateTime CreatedAt { get; set; }

    [Required]
    public int Stock { get; set; }
    
    public ICollection<PCComponent> PCComponents { get; set; } = new List<PCComponent>();
}