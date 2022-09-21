using MediatR;
using RentBizu.Application.LocatarioContext.LocatarioApp.Dto;

namespace RentBizu.Application.LocatarioContext.LocatarioApp.Handler.Command
{
    public class CreateLocatarioCommand : IRequest<CreateLocatarioCommandResponse>
    {
        public LocatarioInputDto Locatario { get; set; }

        public CreateLocatarioCommand(LocatarioInputDto locatario)
        {
            Locatario = locatario;
        }
    }
}
