using MediatR;


namespace RentBizu.Application.LocadorContext.LocadorApp.Handler.Command
{
    public class DeleteLocadorCommand : IRequest<DeleteLocadorCommandResponse>
    {
        public Guid Id { get; set; }

        public DeleteLocadorCommand(Guid id)
        {
            Id = id;
        }
    }
}
