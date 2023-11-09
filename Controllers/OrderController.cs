using System;
using System.Threading.Tasks;
using McDonaldoAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace McDonaldoAPI.Controllers;

[ApiController]
[Route("order")]
public class OrderController : ControllerBase
{
    [HttpPost("create/{storeId}")]
    public async Task<ActionResult> CreateOrder(int storeId, [FromServices]IOrderRepository repo)
    {
        try
        {
            var orderId = await repo.CreateOrder(storeId);
            return Ok(orderId);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("delete/{orderId}")]
    public async Task<ActionResult> CancelOrder(int orderId, [FromServices]IOrderRepository repo)
    {
        try
        {
            await repo.CancelOrder(orderId);
            return Ok("Order canceled with success.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("addItem/{orderId}/{productId}")]
    public async Task<ActionResult> AddItem(int orderId, int productId, [FromServices]IOrderRepository repo)
    {
        try
        {
            await repo.AddItem(orderId, productId);
            return Ok("Item added with success.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
