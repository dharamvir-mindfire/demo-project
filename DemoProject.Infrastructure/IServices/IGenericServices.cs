using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject.Infrastructure.IServices
{
    public interface IGenericServices<T> where T : class
    {
        Task<T?> GetAsync(Int64 id);
        T? Get(Int64 id);
        Task<List<T>> GetAllAsync();
        List<T> GetAll();
        Task<T> AddAsync(T payload);
        T Add(T payload);
        Task<T> UpdateAsync(T payload);
        T Update(T payload);
        Task<string> DeleteAsync(Int64 id);
        string Delete(Int64 id);
    }
}
