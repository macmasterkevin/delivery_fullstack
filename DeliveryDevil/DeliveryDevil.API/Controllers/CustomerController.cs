using DeliveryDevil.API;
using DeliveryDevil.API.DTO;
using DeliveryDevil.Service;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryDevil.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : Controller
{
    private readonly ICustomerService _service;

    public CustomerController(ICustomerService service)
    {
        _service = service;
    }

    [HttpGet("{customerId}")]
    public async Task<IActionResult> Get(int customerId)
    {
        if (customerId <= 0) return BadRequest("Customer Id required");
        var result = await _service.Get(customerId);
        return result != null ? Json(result.FromDomain()) : NotFound();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var results = await _service.GetAll();
        return Json(results.Select(o => o.FromDomain()));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CustomerDto customer)
    {
        if (customer == null) return BadRequest("No customer given");
        var created = await _service.Create(customer.ToDomain());
        return Json(created);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] CustomerDto customer)
    {
        if ((customer?.CustomerId ?? 0) <= 0) return BadRequest("No customer given");
        var updated = await _service.Update(customer.ToDomain());
        if (updated == null) return NotFound();
        return Json(updated);
    }

    [HttpDelete("{customerId}")]
    public async Task<IActionResult> Delete(int customerId)
    {
        await _service.Delete(customerId);
        return Ok();
    }
}