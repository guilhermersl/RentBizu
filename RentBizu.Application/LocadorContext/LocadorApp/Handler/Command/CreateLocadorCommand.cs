using MediatR;
using RentBizu.Application.LocadorContext.LocadorApp.Dto;

namespace RentBizu.Application.LocadorContext.LocadorApp.Handler.Command
{
    public class CreateLocadorCommand : IRequest<CreateLocadorCommandResponse>
    {
        public LocadorInputDto Locador { get; set; }

        public CreateLocadorCommand(LocadorInputDto locador)
        {
            Locador = locador;
        }
    }
}
