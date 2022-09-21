using RentBizu.Application.LocatarioContext.LocatarioApp.Dto;

namespace RentBizu.Application.LocatarioContext.LocatarioApp.Handler.Command
{
    public class CreateLocatarioCommandResponse
    {
        public LocatarioOutputDto Locatario { get; set; }

        public CreateLocatarioCommandResponse(LocatarioOutputDto locatario)
        {
            Locatario = locatario;
        }
    }
}
