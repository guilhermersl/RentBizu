using MediatR;

namespace RentBizu.Application.LocadorContext.PlanoContaApp.Handler.Command
{
    public class DeletePlanoContaCommand : IRequest<DeletePlanoContaCommandResponse>
    {
        public Guid Id { get; set; }

        public DeletePlanoContaCommand(Guid id)
        {
            Id = id;
        }
    }
}
