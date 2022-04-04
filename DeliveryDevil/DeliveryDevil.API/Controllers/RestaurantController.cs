using DeliveryDevil.API;
using DeliveryDevil.API.DTO;
using DeliveryDevil.Service;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryDevil.Controllers;

[ApiController]
[Route("[controller]")]
public class RestaurantController : Controller
{
    private readonly IRestaurantService _service;

    public RestaurantController(IRestaurantService service)
    {
        _service = service;
    }

    [HttpGet("{restaurantId}")]
    public async Task<IActionResult> Get(int restaurantId)
    {
        if (restaurantId <= 0) return BadRequest("Restaurant Id required");
        var result = await _service.Get(restaurantId);
        return result != null ? Json(result.FromDomain()) : NotFound();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var results = await _service.GetAll();
        return Json(results.Select(o => o.FromDomain()));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] RestaurantDto restaurant)
    {
        if (restaurant == null) return BadRequest("No restaurant given");
        var created = await _service.Create(restaurant.ToDomain());
        return Json(created);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] RestaurantDto restaurant)
    {
        if ((restaurant?.RestaurantId ?? 0) <= 0) return BadRequest("No restaurant given");
        var updated = await _service.Update(restaurant.ToDomain());
        if (updated == null) return NotFound();
        return Json(updated);
    }

    [HttpDelete("{restaurantId}")]
    public async Task<IActionResult> Delete(int restaurantId)
    {
        await _service.Delete(restaurantId);
        return Ok();
    }
}