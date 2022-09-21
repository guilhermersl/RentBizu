using RentBizu.Application.LocadorContext.PlanoContaApp.Dto;

namespace RentBizu.Application.LocadorContext.PlanoContaApp.Handler.Query
{
    public class GetPlanoContaQueryResponse
    {
        public PlanoContaOutputDto PlanoConta { get; set; }

        public GetPlanoContaQueryResponse(PlanoContaOutputDto planoConta)
        {
            PlanoConta = planoConta;
        }
    }
}
