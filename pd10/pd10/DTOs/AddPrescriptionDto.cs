using pd10.Models;

namespace pd10.DTOs;

public class AddPrescriptionDto
{
    public List<MedicamentDto> Medicaments { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    
}
public class AddPrescriptionRequestDto
{
    public Patient Patient { get; set; }
    public int IdDoctor { get; set; }
    public AddPrescriptionDto AddPrescriptionDto { get; set; }
}