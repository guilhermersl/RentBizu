using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nest;
using RentBizu.Application.LocadorContext.PlanoContaApp.Dto;
using RentBizu.Application.LocadorContext.PlanoContaApp.Handler.Command;
using RentBizu.Application.LocadorContext.PlanoContaApp.Handler.Query;
using RentBizu.Application.LocadorContext.LocadorApp.Handler.Query;
using System.Net;

namespace LetsMusic.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanoContaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PlanoContaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{locadorId}/{id}")]
        [ProducesResponseType(typeof(PlanoContaOutputDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ListarUm([FromRoute] Guid locadorId, [FromRoute] Guid id)
        {
            var resut = await _mediator.Send(new GetPlanoContaQuery(locadorId, id));
            return Ok(resut.PlanoConta);
        }

        [HttpGet("{locadorId}")]
        [ProducesResponseType(typeof(PlanoContaOutputDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ListarTodos([FromRoute] Guid locadorId)
        {
            var locador = await _mediator.Send(new GetLocadorQuery(locadorId));

            if (locador.Locador is null)
            {
                return BadRequest("Locador inexistente");
            }
            else
            {
                var resut = await _mediator.Send(new GetAllPlanoContaQuery(locadorId));
                return Ok(resut.PlanoContas);
            }
        }

        [HttpPost("{locadorId}")]
        [ProducesResponseType(typeof(PlanoContaOutputDto), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> Criar([FromRoute] Guid locadorId, PlanoContaInputDto dto)
        {
            var locador = await _mediator.Send(new GetLocadorQuery(locadorId));

            if (locador.Locador is null)
            {
                return BadRequest("Locador inexistente");
            }
            else
            {
                var result = await _mediator.Send(new CreatePlanoContaCommand(locadorId, dto));
                return Created($"{result.PlanoConta.Id}", result.PlanoConta);
            }
        }

        [HttpDelete("{locadorId}/{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Excluir([FromRoute] Guid locadorId, [FromRoute] Guid id)
        {
            var locador = await _mediator.Send(new GetLocadorQuery(locadorId));

            if (locador.Locador is null)
            {
                return BadRequest("Locador inexistente");
            }
            else
            {
                var result = await _mediator.Send(new DeletePlanoContaCommand(id));
                return NoContent();
            }            
        }

        [HttpPut("{locadorId}/{id}")]
        [ProducesResponseType(typeof(PlanoContaOutputDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Atualizar([FromRoute] Guid locadorId, [FromRoute] Guid id, PlanoContaInputDto dto)
        {
            var locador = await _mediator.Send(new GetLocadorQuery(locadorId));
            if (locador.Locador is null)
            {
                return BadRequest("Locador inexistente");
            }
            else
            {
                var result = await _mediator.Send(new UpdatePlanoContaCommand(locadorId, id, dto));
                return Created($"{result.PlanoConta.Id}", result.PlanoConta);
            }
        }
    }
}