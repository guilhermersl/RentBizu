using RentBizu.Application.LocadorContext.LocadorApp.Dto;

namespace RentBizu.Application.LocadorContext.LocadorApp.Handler.Query
{
    public class GetLocadorQueryResponse
    {
        public LocadorOutputDto Locador { get; set; }

        public GetLocadorQueryResponse(LocadorOutputDto locador)
        {
            Locador = locador;
        }
    }
}
