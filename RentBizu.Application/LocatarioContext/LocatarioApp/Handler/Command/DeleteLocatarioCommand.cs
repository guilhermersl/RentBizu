using MediatR;


namespace RentBizu.Application.LocatarioContext.LocatarioApp.Handler.Command
{
    public class DeleteLocatarioCommand : IRequest<DeleteLocatarioCommandResponse>
    {
        public Guid Id { get; set; }

        public DeleteLocatarioCommand(Guid id)
        {
            Id = id;
        }
    }
}
