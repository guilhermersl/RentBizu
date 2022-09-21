using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentBizu.Application.LocadorContext.PlanoContaApp.Handler.Query
{
    public class GetPlanoContaQuery : IRequest<GetPlanoContaQueryResponse>
    {
        public Guid LocadorId { get; set; }
        public Guid Id { get; set; }
        
        public GetPlanoContaQuery(Guid locadorId, Guid id)
        {
            LocadorId = locadorId;
            Id = id;
        }
    }
}
