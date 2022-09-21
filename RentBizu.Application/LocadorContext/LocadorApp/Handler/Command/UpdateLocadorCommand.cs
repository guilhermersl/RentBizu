using MediatR;
using RentBizu.Application.LocadorContext.LocadorApp.Dto;

namespace RentBizu.Application.LocadorContext.LocadorApp.Handler.Command
{
    public class UpdateLocadorCommand : IRequest<UpdateLocadorCommandResponse>
    {
        public Guid Id { get; set; }
        public LocadorInputDto Locador { get; set; }

        public UpdateLocadorCommand(Guid id, LocadorInputDto locador)
        {     
            Id = id;
            Locador = locador;
        }
    }
}
