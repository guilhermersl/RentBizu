
using RentBizu.Application.LocadorContext.PlanoContaApp.Dto;

namespace RentBizu.Application.LocadorContext.PlanoContaApp.Handler.Command
{
    public class CreatePlanoContaCommandResponse
    {
        public PlanoContaOutputDto PlanoConta { get; set; }

        public CreatePlanoContaCommandResponse(PlanoContaOutputDto planoConta)
        {
            PlanoConta = planoConta;
        }
    }
}
