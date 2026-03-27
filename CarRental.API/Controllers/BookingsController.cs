// API/Controllers/BookingsController.cs
using System.Security.Claims;
using CarRental.Business.DTOs.Booking;
using CarRental.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookingsController : ControllerBase
{
    private readonly IBookingService _bookingService;

    public BookingsController(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    // GET api/bookings/my — renter sees their own bookings
    [Authorize]
    [HttpGet("my")]
    public async Task<IActionResult> GetMyBookings()
    {
        var renterId = GetUserId();
        var bookings = await _bookingService.GetMyBookingsAsync(renterId);
        return Ok(bookings);
    }

    // GET api/bookings/car/5 — owner sees all bookings for their car
    [Authorize]
    [HttpGet("car/{carId:int}")]
    public async Task<IActionResult> GetBookingsByCar(int carId)
    {
        var ownerId = GetUserId();
        var bookings = await _bookingService.GetBookingsByCarAsync(carId, ownerId);
        return Ok(bookings);
    }

    // GET api/bookings/5 — get single booking by id
    [Authorize]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var booking = await _bookingService.GetBookingByIdAsync(id);
        if (booking == null) return NotFound("Booking not found.");
        return Ok(booking);
    }

    // POST api/bookings — renter creates a booking
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create(CreateBookingDto dto)
    {
        var renterId = GetUserId();
        var booking = await _bookingService.CreateBookingAsync(renterId, dto);
        return CreatedAtAction(nameof(GetById), new { id = booking.Id }, booking);
    }

    // PUT api/bookings/5/cancel — renter or owner cancels a booking
    [Authorize]
    [HttpPut("{id:int}/cancel")]
    public async Task<IActionResult> Cancel(int id)
    {
        var userId = GetUserId();
        await _bookingService.CancelBookingAsync(id, userId);
        return NoContent();
    }

    private int GetUserId()
    {
        return int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
    }
}