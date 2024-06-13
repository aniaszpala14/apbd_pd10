using Microsoft.AspNetCore.Mvc;
using pd10.Services;

namespace pd10.Controllers;

public class PatientsController : ControllerBase
{
    private readonly IDbService _dbService;

    public PatientsController(IDbService dbService)
    {
        _dbService = dbService;
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPatient(int id)
    {
        var result = await _dbService.GetPatientInfo(id);

        return Ok(result);
    }



}