using MediatR;
using RentBizu.Application.LocadorContext.PlanoContaApp.Dto;

namespace RentBizu.Application.LocadorContext.PlanoContaApp.Handler.Command
{
    public class CreatePlanoContaCommand : IRequest<CreatePlanoContaCommandResponse>
    {
        public Guid LocadorId { get; set; }
        public PlanoContaInputDto PlanoConta { get; set; }

        public CreatePlanoContaCommand(Guid locadorId, PlanoContaInputDto planoConta)
        {
            LocadorId = locadorId;
            PlanoConta = planoConta;
        }
    }
}
