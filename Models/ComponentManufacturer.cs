using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_TASK_7.Models;

[Table("ComponentManufacturers")]
public class ComponentManufacturer
{
    [Key]
    public int Id { get; set; }

    [Required] [MaxLength(30)] public string Abbreviation { get; set; } = null!;
    
    [Required] [MaxLength(300)] public string FullName { get; set; } = null!;

    [Required]
    public DateTime FoundationDate{get; set;}
    
    public ICollection<Component> Components { get; set; } = new List<Component>();
}