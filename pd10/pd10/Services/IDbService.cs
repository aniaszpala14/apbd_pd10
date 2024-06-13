using pd10.DTOs;
using pd10.Models;

namespace pd10.Services;

public interface IDbService
{

    Task<Prescription> AddPrescription(Patient patient, int IdDoctor, AddPrescriptionDto adprescriptionDto);
    Task<bool> DoesMedicineExist(int id);
    Task<bool> DoesPatientExist(int id);
    Task<PatientDto> GetPatientInfo(int id);
}