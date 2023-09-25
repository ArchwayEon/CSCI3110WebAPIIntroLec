using CSCI3110WebAPIIntroLec.Models.Entities;
using CSCI3110WebAPIIntroLec.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CSCI3110WebAPIIntroLec.Controllers;

[EnableCors]
[Route("api/[controller]")]
[ApiController]
public class PetController : ControllerBase
{
    private readonly IPetRepository _petRepo;

    public PetController(IPetRepository petRepo)
    {
        _petRepo = petRepo;
    }

    [HttpGet("all")]
    public IActionResult Get()
    {
        return Ok(_petRepo.ReadAll());
    }

    [HttpPost("create")]
    public IActionResult Post([FromForm] Pet pet)
    {
        _petRepo.Create(pet);
        return CreatedAtAction("Get", new { id = pet.Id }, pet);
    }

}
