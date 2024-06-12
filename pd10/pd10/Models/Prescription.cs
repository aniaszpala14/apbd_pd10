using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pd10.Models;

[Table("Prescription")]
public class Prescription
{
    [Key]
    public int IdPrescription { get; set; }
    [Required]
    public DateTime Date { get; set; }
    [Required]
    public DateTime DueDate { get; set; }
    [Required]
    [ForeignKey("IdPatient")]
    public int IdPatient { get; set; }
    [Required]
    [ForeignKey("IdDoctor")]
    public int IdDoctor { get; set; }
}