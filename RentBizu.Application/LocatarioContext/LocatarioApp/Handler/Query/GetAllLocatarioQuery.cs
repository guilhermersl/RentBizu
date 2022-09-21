using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentBizu.Application.LocatarioContext.LocatarioApp.Handler.Query
{
    public class GetAllLocatarioQuery : IRequest<GetAllLocatarioQueryResponse>{ }
}
