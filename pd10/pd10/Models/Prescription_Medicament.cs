using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace pd10.Models;
[Table("Prescription_Medicament")]
[PrimaryKey(nameof(IdPrescription), nameof(IdMedicament))]
public class Prescription_Medicament
{
    public int IdPrescription { get; set; }
    public int IdMedicament { get; set; }
    public int Dose { get; set; }
    [Required]
    public string Details { get; set; }
}