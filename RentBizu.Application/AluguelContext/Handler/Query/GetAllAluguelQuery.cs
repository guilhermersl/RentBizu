using MediatR;

namespace RentBizu.Application.AluguelContext.Handler.Query
{
    public class GetAllAluguelQuery : IRequest<GetAllAluguelQueryResponse>
    {
        public Guid LocatarioId { get; set; }

        public GetAllAluguelQuery(Guid locatarioId)
        {
            LocatarioId = locatarioId;
        }
    
    }
}
