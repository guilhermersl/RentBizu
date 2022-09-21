using MediatR;

namespace RentBizu.Application.LocadorContext.LocadorApp.Handler.Query
{
    public class GetLocadorQuery : IRequest<GetLocadorQueryResponse>
    {
        public Guid Id { get; set; }

        public GetLocadorQuery(Guid id)
        {
            Id = id;
        }
    }
}
