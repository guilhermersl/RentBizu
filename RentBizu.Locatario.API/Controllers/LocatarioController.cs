using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentBizu.Application.LocatarioContext.LocatarioApp.Dto;
using RentBizu.Application.LocatarioContext.LocatarioApp.Handler.Command;
using RentBizu.Application.LocatarioContext.LocatarioApp.Handler.Query;
using System.Net;

namespace LetsMusic.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocatarioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LocatarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(LocatarioOutputDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ListarUm([FromRoute] Guid id)
        {
            var resut = await _mediator.Send(new GetLocatarioQuery(id));
            return Ok(resut.Locatario);
        }

        [HttpGet]
        [ProducesResponseType(typeof(LocatarioOutputDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ListarTodos()
        {
            var resut = await _mediator.Send(new GetAllLocatarioQuery());
            return Ok(resut.Locatarios);
        }

        [HttpPost]
        [ProducesResponseType(typeof(LocatarioOutputDto), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> Criar(LocatarioInputDto dto)
        {
            var result = await _mediator.Send(new CreateLocatarioCommand(dto));
            return Created($"{result.Locatario.Id}", result.Locatario);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Excluir([FromRoute] Guid id)
        {
            var result = await _mediator.Send(new DeleteLocatarioCommand(id));
            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(LocatarioOutputDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Atualizar([FromRoute] Guid id, LocatarioInputDto dto)
        {
            //var resutGet = await _mediator.Send(new GetLocatarioQuery(id));

            //if (resutGet != null)
           // {
                var result = await _mediator.Send(new UpdateLocatarioCommand(id, dto));
                return Created($"{result.Locatario.Id}", result.Locatario);
            //}
            //else
            //{
            //    return NoContent();
            //}


        }
    }
}