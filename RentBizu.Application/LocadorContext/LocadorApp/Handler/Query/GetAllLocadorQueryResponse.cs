using RentBizu.Application.LocadorContext.LocadorApp.Dto;

namespace RentBizu.Application.LocadorContext.LocadorApp.Handler.Query
{
    public class GetAllLocadorQueryResponse
    {
        public IList<LocadorOutputDto> Locadores { get; set; }

        public GetAllLocadorQueryResponse(IList<LocadorOutputDto> locadores)
        {
            Locadores = locadores;
        }
    }
}
