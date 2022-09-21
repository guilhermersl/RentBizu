using RentBizu.Application.LocatarioContext.LocatarioApp.Dto;

namespace RentBizu.Application.LocatarioContext.LocatarioApp.Handler.Query
{
    public class GetLocatarioQueryResponse
    {
        public LocatarioOutputDto Locatario { get; set; }

        public GetLocatarioQueryResponse(LocatarioOutputDto locatario)
        {
            Locatario = locatario;
        }
    }
}
