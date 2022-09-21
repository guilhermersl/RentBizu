using RentBizu.Data.Database;
using RentBizu.Data.Contexto;
using RentBizu.Domain.LocadorContext;
using RentBizu.Domain.LocadorContext.Repositories;
using Microsoft.EntityFrameworkCore;

namespace RentBizu.Data.Repository
{
    public class PlanoContaRepository : Repository<PlanoConta>, IPlanoContaRepository
    {
        public PlanoContaRepository(RentBizuContext context) : base(context) { }

        public async Task<PlanoConta> GetOneWithIncludes(Guid id)
        {
            return Query.Include(planoConta => planoConta.Alugueis)
                .FirstOrDefault(planoConta => planoConta.Id == id);
        }
    }
}
