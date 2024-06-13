using Microsoft.AspNetCore.Mvc;
using pd10.DTOs;
using pd10.Models;
using pd10.Services;

namespace pd10.Controllers;

[ApiController]
[Route("[controller]")]
public class PrescriptionsController : ControllerBase
{
    private readonly IDbService _dbService;

    public PrescriptionsController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpPost]
    public async Task<IActionResult> AddPrescription([FromBody] AddPrescriptionRequestDto request)
    {
        if (request.AddPrescriptionDto.DueDate < request.AddPrescriptionDto.Date)
        {
            return BadRequest("Due date before the date");
        }

        if (request.AddPrescriptionDto.Medicaments.Count > 10)
        {
            return BadRequest("Over 10");
        }

        foreach (var med in request.AddPrescriptionDto.Medicaments)
        {
            if (!await _dbService.DoesMedicineExist(med.IdMedicament))
            {
                throw new ArgumentException("Medicine does not exsist");
            }
        }

        var prescription = await _dbService.AddPrescription(request.Patient, request.IdDoctor, request.AddPrescriptionDto); 
        return Ok(prescription);
    }



}