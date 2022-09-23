using MediatR;

namespace RentBizu.Application.AluguelContext.Handler.Command
{
    public class DeleteAluguelCommand : IRequest<DeleteAluguelCommandResponse>
    {
        public Guid Id { get; set; }

        public DeleteAluguelCommand(Guid id)
        {
            Id = id;
        }
    }
}
