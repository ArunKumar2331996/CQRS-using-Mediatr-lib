using Mediator_Pattern.Model;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Mediator_Pattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("id")]
        public async Task<IActionResult> GetItemById(string id)
        {
            var result = await _mediator.Send(new GetItemById(id));
            return result != null ? Ok(result) : (IActionResult)NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post([Bind("Id,Name,Description,Completed")] Item item)
        {
            await _mediator.Send(new CreateItem(item));
            return Created("Record inserted successfully", item);
        }

        [HttpPut("id")]
        public async Task<IActionResult> Put([Bind("Id,Name,Description,Completed")] Item item, string id)
        {
            item.Id = id;
            await _mediator.Send(new UpdateItem(item));
            return NoContent();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(string id)
        {
            await _mediator.Send(new DeleteItem(id));
            return NoContent();
        }
    }
}
