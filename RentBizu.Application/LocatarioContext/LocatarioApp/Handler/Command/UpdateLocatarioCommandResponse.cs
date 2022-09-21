using RentBizu.Application.LocatarioContext.LocatarioApp.Dto;

namespace RentBizu.Application.LocatarioContext.LocatarioApp.Handler.Command
{
    public class UpdateLocatarioCommandResponse
    {
        public LocatarioOutputDto Locatario { get; set; }

        public UpdateLocatarioCommandResponse(LocatarioOutputDto locatario)
        {
            Locatario = locatario;
        }
    }
}
