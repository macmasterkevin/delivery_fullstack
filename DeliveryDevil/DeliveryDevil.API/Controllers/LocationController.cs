using DeliveryDevil.API;
using DeliveryDevil.API.DTO;
using DeliveryDevil.Service;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryDevil.Controllers;

[ApiController]
[Route("[controller]")]
public class LocationController : Controller
{
    private readonly ILocationService _service;

    public LocationController(ILocationService service)
    {
        _service = service;
    }

    [HttpGet("{addressId}")]
    public async Task<IActionResult> Get(int addressId)
    {
        if (addressId <= 0) return BadRequest("Address Id required");
        var result = await _service.Get(addressId);
        return result != null ? Json(result.FromDomain()) : NotFound();
    }

    [HttpGet("regions")]
    public async Task<IActionResult> GetAll()
    {
        var results = await _service.GetAllRegions();
        return Json(results.Select(o => o.FromDomain()));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AddressDto address)
    {
        if (address == null) return BadRequest("No address given");
        var created = await _service.Create(address.ToDomain());
        return Json(created);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] AddressDto address)
    {
        if ((address?.AddressId ?? 0) <= 0) return BadRequest("No address given");
        var updated = await _service.Update(address.ToDomain());
        if (updated == null) return NotFound();
        return Json(updated);
    }

    [HttpDelete("{addressId}")]
    public async Task<IActionResult> Delete(int addressId)
    {
        await _service.Delete(addressId);
        return Ok();
    }
}