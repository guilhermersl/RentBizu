using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RentBizu.CrossCutting.Interfaces.Data
{
    public interface IRepositoryRentBizu<T> where T : class
    {
        Task Save(T entity);
        Task Update(object id, T entity);
        Task Delete(T entity);
        Task<T?> Get(object id);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T?>> FindAllByCriteria(Expression<Func<T, bool>> expression);
        Task<T?> FindOneByCriteria(Expression<Func<T, bool>> expression);

        Task<IDbContextTransaction> CreatTransaction();
        Task<IDbContextTransaction> CreatTransaction(IsolationLevel isolation);
    }
}
