using RentBizu.Application.LocatarioContext.LocatarioApp.Dto;

namespace RentBizu.Application.LocatarioContext.LocatarioApp.Handler.Query
{
    public class GetAllLocatarioQueryResponse
    {
        public IList<LocatarioOutputDto> Locatarios { get; set; }

        public GetAllLocatarioQueryResponse(IList<LocatarioOutputDto> locatarios)
        {
            Locatarios = locatarios;
        }
    }
}
