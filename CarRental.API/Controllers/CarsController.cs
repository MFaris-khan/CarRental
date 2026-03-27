// API/Controllers/CarsController.cs
using System.Security.Claims;
using CarRental.Business.DTOs.Car;
using CarRental.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarsController : ControllerBase
{
    private readonly ICarService _carService;

    public CarsController(ICarService carService)
    {
        _carService = carService;
    }

    // GET api/cars — public, no token needed
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var cars = await _carService.GetAllCarsAsync();
        return Ok(cars);
    }

    // GET api/cars/5 — public, no token needed
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var car = await _carService.GetCarByIdAsync(id);
        if (car == null) return NotFound("Car not found.");
        return Ok(car);
    }

    // GET api/cars/my — only logged in owners see their own cars
    [Authorize]
    [HttpGet("my")]
    public async Task<IActionResult> GetMyCars()
    {
        var ownerId = GetUserId();
        var cars = await _carService.GetCarsByOwnerAsync(ownerId);
        return Ok(cars);
    }

    // POST api/cars — must be logged in to list a car
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create(CreateCarDto dto)
    {
        var ownerId = GetUserId();
        var car = await _carService.CreateCarAsync(ownerId, dto);
        return CreatedAtAction(nameof(GetById), new { id = car.Id }, car);
    }

    // PUT api/cars/5 — only the owner can update
    [Authorize]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateCarDto dto)
    {
        var ownerId = GetUserId();
        await _carService.UpdateCarAsync(id, ownerId, dto);
        return NoContent();
    }

    // DELETE api/cars/5 — only the owner can delete
    [Authorize]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var ownerId = GetUserId();
        await _carService.DeleteCarAsync(id, ownerId);
        return NoContent();
    }

    private int GetUserId()
    {
        return int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
    }
}