using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_TASK_7.Models;

[Table("Components")]
public class Component
{
    [Key] [Column(TypeName = "char(10)")] 
    public string Code { get; set; } = null!;

    [Required] [MaxLength(300)] public string Name { get; set; } = null!; 
    
    [MaxLength(4000)]
    public string? Description { get; set; } 
    
    [Required]
    public int ComponentManufacturerId { get; set; }

    [ForeignKey(nameof(ComponentManufacturerId))]
    public ComponentManufacturer Manufacturer { get; set; } = null!;
    
    [Required]
    public int ComponentTypesId { get; set; }

    [ForeignKey(nameof(ComponentTypesId))] public ComponentType Type { get; set; } = null!;
    
    public ICollection<Component> Components { get; set; } = new List<Component>();

}