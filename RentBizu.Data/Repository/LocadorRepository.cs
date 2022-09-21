using RentBizu.Data.Database;
using Microsoft.EntityFrameworkCore;
using RentBizu.Data.Contexto;
using RentBizu.Data.Database;
using RentBizu.Domain.LocadorContext;
using RentBizu.Domain.LocadorContext.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace RentBizu.Data.Repository
{
    public class LocadorRepository : Repository<Locador>, ILocadorRepository
    {
        public LocadorRepository(RentBizuContext context) : base(context) { }
        public async Task<Locador> GetOneWithIncludes(Guid id)
        {
            return Query.Include(locador => locador.PlanoContas)
                .FirstOrDefault(locador => locador.Id == id);
        }
    }
}
