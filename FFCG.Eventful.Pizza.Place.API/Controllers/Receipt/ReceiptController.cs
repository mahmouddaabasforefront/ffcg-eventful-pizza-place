
using FFCG.Eventful.Pizza.Place.Controllers.Receipt.ApiModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FFCG.Eventful.Pizza.Place.Controllers.Receipt;

[ApiController]
[Route("receipt")]
public class ReceiptController(ISender _sender) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateReceipt([FromBody] CreateNewReceiptApiModel model)
    {
        var result = await _sender.Send(model.MapToCommand());
        return Created(result.Id.ToString(), result);
    }

    /*[HttpGet]
    public async Task<IActionResult> GetAllReceipts()
    {
        return Ok(await _sender.Send(new GetAllPizzasQuery()));
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetReceiptById(Guid id)
    {
        return Ok(await _sender.Send(new GetPizzaByIdQuery(id)));
    }*/
}