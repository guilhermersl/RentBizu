using RentBizu.CrossCutting.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentBizu.Domain.LocatarioContext.Repositories
{
    public interface ILocatarioRepository : IRepositoryRentBizu<Locatario>
    {
        public Task<Locatario> GetOneWithIncludes(Guid id);
    }
}
