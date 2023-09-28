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

    [HttpGet("one/{id}")]
    public IActionResult Get(int id)
    {
        var pet = _petRepo.Read(id);
        if (pet == null)
        {
            return NotFound();
        }
        return Ok(pet);
    }

    [HttpPut("update")]
    public IActionResult Put([FromForm] Pet pet)
    {
        _petRepo.Update(pet.Id, pet);
        return NoContent(); // 204 as per HTTP specification
    }

    [HttpDelete("delete/{id}")]
    public IActionResult Delete(int id)
    {
        _petRepo.Delete(id);
        return NoContent(); // 204 as per HTTP specification
    }

}
