using MediatR;

namespace RentBizu.Application.LocatarioContext.LocatarioApp.Handler.Query
{
    public class GetLocatarioQuery : IRequest<GetLocatarioQueryResponse>
    {
        public Guid Id { get; set; }

        public GetLocatarioQuery(Guid id)
        {
            Id = id;
        }
    }
}
