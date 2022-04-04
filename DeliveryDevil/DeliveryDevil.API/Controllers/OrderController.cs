using DeliveryDevil.API;
using DeliveryDevil.API.DTO;
using DeliveryDevil.Service;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryDevil.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : Controller
{
    private readonly IOrderService _service;

    public OrderController(IOrderService service)
    {
        _service = service;
    }

    [HttpGet("{orderId}")]
    public async Task<IActionResult> Get(int orderId)
    {
        if (orderId <= 0) return BadRequest("Order Id required");
        var order = await _service.Get(orderId);
        return order != null ? Json(order.FromDomain()) : NotFound();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var orders = await _service.GetAll();
        return Json(orders.Select(o => o.FromDomain()));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] OrderDto order)
    {
        if (order == null) return BadRequest("No order given");
        var createdOrder = await _service.Create(order.ToDomain());
        return Json(createdOrder);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody]OrderDto order)
    {
        if ((order?.OrderId ?? 0) <= 0) return BadRequest("No order given");
        var updatedOrder = await _service.Update(order.ToDomain());
        if (updatedOrder == null) return NotFound();
        return Json(updatedOrder);
    }

    [HttpPatch("{orderId}/complete")]
    public async Task<IActionResult> Complete(int orderId, [FromQuery]bool didTip = false)
    {
        await _service.Complete(orderId, didTip);
        return Ok();
    }

    [HttpGet("history/{customerId}")]
    public async Task<IActionResult> GetHistory(int customerId, [FromQuery]bool orderByRecent)
    {
        var orders = await _service.GetHistory(customerId, orderByRecent);
        if (!orders?.Any() ?? true) return NotFound();
        return Json(orders.Select(o => o.FromDomain()));
    }

    [HttpDelete("{orderId}")]
    public async Task<IActionResult> Delete(int orderId)
    {
        await _service.Delete(orderId);
        return Ok();
    }
}