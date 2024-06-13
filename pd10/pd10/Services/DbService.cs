using System.Runtime.InteropServices.JavaScript;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using pd10.Data;
using pd10.DTOs;
using pd10.Models;

namespace pd10.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }
    
    public async Task<Prescription> AddPrescription(Patient patient,int IdDoctor,AddPrescriptionDto adprescriptionDto)
    {

        if (!await DoesPatientExist(patient.IdPatient))
        {
            var newpatient = new Patient
            {
                IdPatient = patient.IdPatient,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Birthdate = patient.Birthdate
            };
            _context.Patients.Add(newpatient);
            await _context.SaveChangesAsync();
        }


        var result = new Prescription
        {
            Date = adprescriptionDto.Date,
            DueDate = adprescriptionDto.DueDate,
            IdPatient = patient.IdPatient,
            IdDoctor = IdDoctor,
            PrescriptionMedicaments = adprescriptionDto.Medicaments.Select(x => new Prescription_Medicament
            {
                IdMedicament = x.IdMedicament,
            }).ToList()
        };
        _context.Prescriptions.Add(result);
        await _context.SaveChangesAsync();
        
        return result;
    }
    
    
    
    public async Task<bool> DoesPatientExist(int id)
    {
        return await _context.Patients.AnyAsync(x => x.IdPatient == id);
    }
    public async Task<bool> DoesMedicineExist(int id)
    {
        return await _context.Medicaments.AnyAsync(x => x.IdMedicament == id);
    }

    public async Task<PatientDto> GetPatientInfo(int id)
    {
        var result = await _context.Patients
            .Include(p => p.Prescriptions)
            .ThenInclude(pr => pr.PrescriptionMedicaments)
            .ThenInclude(pm => pm.Medicament)
            .Include(p => p.Prescriptions)
            .ThenInclude(pr => pr.Doctor)
            .Where(p => p.IdPatient == id)
            .Select(p => new PatientDto
            {
                FirstName = p.FirstName,
                LastName = p.LastName,
                Prescriptions = p.Prescriptions.Select(pr => new GetPrescriptionDto()
                {
                    IdPrescription = pr.IdPrescription,
                    Date = pr.Date,
                    DueDate = pr.DueDate,
                    Medicaments = pr.PrescriptionMedicaments.Select(pm => new MedicamentDto // Change this line
                    {
                        IdMedicament = pm.Medicament.IdMedicament,
                        Dose = pm.Dose,
                        Name = pm.Medicament.Name,
                        Description = pm.Medicament.Description
                    }).ToList(),
                    Doctor = new DoctorDto
                    {
                        IdDoctor = pr.Doctor.IdDoctor,
                        FirstName = pr.Doctor.FirstName,
                    }
                }).ToList() 
            }).FirstOrDefaultAsync();
                
        return result;
    }

}