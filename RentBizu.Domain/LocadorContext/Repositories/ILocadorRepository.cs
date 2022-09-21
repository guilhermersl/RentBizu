using RentBizu.CrossCutting.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentBizu.Domain.LocadorContext.Repositories
{
    public interface ILocadorRepository : IRepositoryRentBizu<Locador> 
    {
        public Task<Locador> GetOneWithIncludes(Guid id);    
    }
}
