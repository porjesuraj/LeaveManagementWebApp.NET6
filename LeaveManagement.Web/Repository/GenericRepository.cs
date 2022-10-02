using LeaveManagement.Web.Data;
using LeaveManagement.Web.IRepository;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Web.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T: class
    {
        private readonly ApplicationDbContext _context;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;             
        }
        public async Task<T> AddAsync(T entity)
        {
           await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;

        }

        public async Task<int> AddRangeAsync(List<T> entities)
        {
            await _context.AddRangeAsync(entities);
            return  await _context.SaveChangesAsync();

        }

        public async Task<int> DeleteAsync(int? id)
        {
            var entity = await GetAsync(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
            }

           return await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistAsync(int? id)
        {
            var entity = await GetAsync(id);
            return entity != null;

        }

        public async Task<List<T>> GetAllAsnyc()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(int? id)
        {
            if (id is null)
                return null;
            var result =  await _context.Set<T>().FindAsync(id);

#pragma warning disable CS8603 // Possible null reference return.
            return result ?? null;
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<int> UpdateAsync(int? id, T entity)
        {
            if(id != null)
            {
                _context.Update(entity);
                return await _context.SaveChangesAsync();
            }

            return 0;

        }
    }
}
