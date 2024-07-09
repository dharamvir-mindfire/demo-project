using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject.Infrastructure.IServices
{
    public interface IGenericServices
    {
        Task<T> GetAsync<T>(Int64 id);
        T Get<T>(Int64 id);
        Task<List<T>> GetAllAsync<T>();
        List<T> GetAll<T>();
        Task<T> AddAsync<T>();
        T Add<T>();
        Task<T> UpdateAsync<T>();
        T Update<T>();
        Task<T> DeleteAsync<T>();
        T Delete<T>(Int64 id);
    }
}
