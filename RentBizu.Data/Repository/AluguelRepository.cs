using RentBizu.Data.Database;
using Microsoft.EntityFrameworkCore;
using RentBizu.Data.Contexto;
using RentBizu.Data.Database;
using RentBizu.Domain.AluguelContext;
using RentBizu.Domain.AluguelContext.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using RentBizu.Domain.LocadorContext;
using RentBizu.Domain.LocadorContext.Repositories;

namespace RentBizu.Data.Repository
{
    public class AluguelRepository : Repository<Aluguel>, IAluguelRepository
    {
        public AluguelRepository(RentBizuContext context) : base(context) { }
    }
}
