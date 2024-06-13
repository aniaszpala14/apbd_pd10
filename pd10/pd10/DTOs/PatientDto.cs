using pd10.Models;

namespace pd10.DTOs;

public class PatientDto
{
   public string FirstName { get; set; }
   public string LastName { get; set; }
   public ICollection<GetPrescriptionDto> Prescriptions { get; set; }
   
}