using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_TASK_7.Models;

[Table("PCComponents")]
public class PCComponent
{
    [Required]
    public int PCId { get; set; } 

    [ForeignKey(nameof(PCId))]
    public PC PC { get; set; } = null!;

    [Required]
    [Column(TypeName = "char(10)")]
    public string ComponentCode { get; set; } = null!; 

    [ForeignKey(nameof(ComponentCode))]
    public Component Component { get; set; } = null!;

    [Required]
    public int Amount { get; set; }
}