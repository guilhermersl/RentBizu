using MediatR;
using RentBizu.Application.LocatarioContext.LocatarioApp.Dto;

namespace RentBizu.Application.LocatarioContext.LocatarioApp.Handler.Command
{
    public class UpdateLocatarioCommand : IRequest<UpdateLocatarioCommandResponse>
    {
        public Guid Id { get; set; }
        public LocatarioInputDto Locatario { get; set; }

        public UpdateLocatarioCommand(Guid id, LocatarioInputDto locatario)
        {     
            Id = id;
            Locatario = locatario;
        }
    }
}
