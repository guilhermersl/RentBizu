using MediatR;
using RentBizu.Application.LocadorContext.PlanoContaApp.Dto;

namespace RentBizu.Application.LocadorContext.PlanoContaApp.Handler.Command
{
    public class UpdatePlanoContaCommand : IRequest<UpdatePlanoContaCommandResponse>
    {
        public Guid LocadorId { get; set; }
        public Guid Id { get; set; }
        public PlanoContaInputDto PlanoConta { get; set; }

        public UpdatePlanoContaCommand(Guid locadorId, Guid id, PlanoContaInputDto planoConta)
        {
            LocadorId = locadorId;
            Id = id;
            PlanoConta = planoConta;
        }
    }
}
