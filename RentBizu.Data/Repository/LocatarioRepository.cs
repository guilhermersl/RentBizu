using RentBizu.Data.Database;
using Microsoft.EntityFrameworkCore;
using RentBizu.Data.Contexto;
using RentBizu.Data.Database;
using RentBizu.Domain.LocadorContext;
using RentBizu.Domain.LocadorContext.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using RentBizu.Domain.LocatarioContext.Repositories;
using RentBizu.Domain.LocatarioContext;

namespace RentBizu.Data.Repository
{
    public class LocatarioRepository : Repository<Locatario>, ILocatarioRepository
    {
        public LocatarioRepository(RentBizuContext context) : base(context) { }

        public async Task<Locatario> GetOneWithIncludes(Guid id)
        {
            return Query.Include(locatario => locatario.Alugueis)
                .FirstOrDefault(locatario => locatario.Id == id);

        //    //public async Task<IEnumerable<Locador>> GetAllWithIncludes()
        //    //{
        //    //    return await Query.Include(locador => locador.PlanoContas)
        //    //                      .ThenInclude(planoConta => planoConta.N)
        //    //                      .ToListAsync();
        //    //}
        }
    }
}
