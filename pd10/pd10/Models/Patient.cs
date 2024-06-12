using System.ComponentModel.DataAnnotations;

namespace pd10.Models;

public class Patient
{
    [Key]
    public int IdPatient { get; set; }
    [MaxLength(100)]
    [Required]
    public string FirstName { get; set; }
    [MaxLength(100)]
    [Required]
    public string LastName { get; set; }
    [Required]
    public DateTime Birthdate { get; set; }
}