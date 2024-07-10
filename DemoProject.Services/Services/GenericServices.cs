using DemoProject.Database;
using DemoProject.Infrastructure.IServices;
using Microsoft.EntityFrameworkCore;

namespace DemoProject.Services.Services
{
    public class GenericServices<T> : IGenericServices<T> where T : class
    {
        private readonly AppDbContext _dbContext;
        public GenericServices(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<T?> GetAsync(Int64 id)
        {
            var data = await _dbContext.FindAsync<T>(id);
            return data;
        }
        public T? Get(Int64 id)
        {
            var data = _dbContext.Find<T>(id);
            return data;
        }

        public async Task<List<T>> GetAllAsync()
        {
            var data = await _dbContext.Set<T>().ToListAsync();
            return data;
        }
        public List<T> GetAll()
        {
            var data = _dbContext.Set<T>().ToList();
            return data;
        }
        public async Task<T> AddAsync(T payload)
        {
            await _dbContext.AddAsync(payload);
            await _dbContext.SaveChangesAsync();
            return payload;
        }
        public T Add(T payload)
        {
            _dbContext.Add(payload);
            _dbContext.SaveChanges();
            return payload;
        }
        public async Task<T> UpdateAsync(T payload)       {
            _dbContext.Attach<T>(payload);
            _dbContext.Entry(payload).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return payload;
        }
        public T Update(T payload)
        {
            _dbContext.Attach<T>(payload);
            _dbContext.Entry(payload).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return payload;
        }
        public async Task<string> DeleteAsync(Int64 id)
        {
            var existing = await _dbContext.FindAsync<T>(id);
            if (existing != null)
            {
                _dbContext.Remove(existing);
                await _dbContext.SaveChangesAsync();
                return "Deleted Successfully";
            }
            else
            {
                return "Not found";
            }
        }
        public string Delete(Int64 id)
        {
            var existing = _dbContext.Find<T>(id);
            if (existing != null)
            {
                _dbContext.Remove(existing);
                _dbContext.SaveChanges();
                return "Deleted Successfully";
            }
            else
            {
                return "Not found";
            }
        }
    }
}
