using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentBizu.Application.LocadorContext.PlanoContaApp.Handler.Query;
using RentBizu.Application.LocadorContext.LocadorApp.Dto;
using RentBizu.Application.LocadorContext.LocadorApp.Handler.Command;
using RentBizu.Application.LocadorContext.LocadorApp.Handler.Query;
using System.Net;

namespace LetsMusic.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocadorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LocadorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(LocadorOutputDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ListarUm([FromRoute] Guid id)
        {
            var resut = await _mediator.Send(new GetLocadorQuery(id));
            return Ok(resut.Locador);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<LocadorOutputDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ListarTodos()
        {
            var resut = await _mediator.Send(new GetAllLocadorQuery());
            return Ok(resut.Locadores);
        }

        [HttpPost]
        [ProducesResponseType(typeof(LocadorOutputDto), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> Criar(LocadorInputDto dto)
        {
            var result = await _mediator.Send(new CreateLocadorCommand(dto));
            return Created($"{result.Locador.Id}", result.Locador);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Excluir([FromRoute] Guid id)
        {
            var result = await _mediator.Send(new DeleteLocadorCommand(id));
            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(LocadorOutputDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Atualizar([FromRoute] Guid id, LocadorInputDto dto)
        {
            //var resutGet = await _mediator.Send(new GetLocadorQuery(id));

            //if (resutGet != null)
           // {
                var result = await _mediator.Send(new UpdateLocadorCommand(id, dto));
                return Created($"{result.Locador.Id}", result.Locador);
            //}
            //else
            //{
            //    return NoContent();
            //}


        }
    }
}