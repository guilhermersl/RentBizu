using RentBizu.Application.LocadorContext.PlanoContaApp.Dto;

namespace RentBizu.Application.LocadorContext.PlanoContaApp.Handler.Query
{
    public class GetAllPlanoContaQueryResponse
    {
        public IList<PlanoContaOutputDto> PlanoContas { get; set; }

        public GetAllPlanoContaQueryResponse(IList<PlanoContaOutputDto> planoContas)
        {
            PlanoContas = planoContas;
        }
    }
}
