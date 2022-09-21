using MediatR;

namespace RentBizu.Application.LocadorContext.PlanoContaApp.Handler.Query
{
    public class GetAllPlanoContaQuery : IRequest<GetAllPlanoContaQueryResponse>
    {
        public Guid LocadorId { get; set; }

        public GetAllPlanoContaQuery(Guid locadorId)
        {
            LocadorId = locadorId;
        }
    
    }
}
