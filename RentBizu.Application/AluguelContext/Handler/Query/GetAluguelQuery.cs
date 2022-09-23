using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentBizu.Application.AluguelContext.Handler.Query
{
    public class GetAluguelQuery : IRequest<GetAluguelQueryResponse>
    {
        public Guid LocadorId { get; set; }
        public Guid Id { get; set; }
        
        public GetAluguelQuery(Guid locadorId, Guid id)
        {
            LocadorId = locadorId;
            Id = id;
        }
    }
}
