using RentBizu.Application.LocadorContext.PlanoContaApp.Dto;
using RentBizu.Application.LocadorContext.LocadorApp.Dto;

namespace RentBizu.Application.LocadorContext.PlanoContaApp.Handler.Command
{
    public class UpdatePlanoContaCommandResponse
    {
        public PlanoContaOutputDto PlanoConta { get; set; }

        public UpdatePlanoContaCommandResponse(PlanoContaOutputDto planoConta)
        {
            PlanoConta = planoConta;
        }
    }
}
