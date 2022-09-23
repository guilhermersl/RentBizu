using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentBizu.Application.AluguelContext.Handler.Query;
using RentBizu.Application.AluguelContext.Dto;
using RentBizu.Application.AluguelContext.Handler.Command;
using RentBizu.Application.AluguelContext.Handler.Query;
using System.Net;
using RentBizu.Application.AluguelContext.Dto;

namespace LetsMusic.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AluguelController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AluguelController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{locatarioId}/{id}")]
        [ProducesResponseType(typeof(AluguelOutputDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ListarUm([FromRoute] Guid locatarioId, [FromRoute] Guid id)
        {
            var resut = await _mediator.Send(new GetAluguelQuery(locatarioId, id));
            return Ok(resut.Aluguel);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<AluguelOutputDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ListarTodos([FromRoute] Guid locatarioId)
        {
            var resut = await _mediator.Send(new GetAllAluguelQuery(locatarioId));
            return Ok(resut.Alugueis);
        }

        [HttpPost("{locatarioId}/{planoContaId}")]
        [ProducesResponseType(typeof(AluguelOutputDto), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> Criar([FromRoute] Guid locatarioId, [FromRoute] Guid planoContaId, AluguelInputDto dto)
        {
            var result = await _mediator.Send(new CreateAluguelCommand(locatarioId, planoContaId, dto));
            return Created($"{result.Aluguel.Id}", result.Aluguel);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Excluir([FromRoute] Guid id)
        {
            var result = await _mediator.Send(new DeleteAluguelCommand(id));
            return NoContent();
        }

        [HttpPut("{locatarioId}/{planoContaId}/{id}")]
        [ProducesResponseType(typeof(AluguelOutputDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Atualizar([FromRoute] Guid locatarioId, [FromRoute] Guid planoContaId, [FromRoute] Guid id, AluguelInputDto dto)
        {
            var result = await _mediator.Send(new UpdateAluguelCommand(locatarioId, planoContaId, id, dto));
            return Created($"{result.Aluguel.Id}", result.Aluguel);
        }
    }
}