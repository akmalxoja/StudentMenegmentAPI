using Microsoft.EntityFrameworkCore;
using Permission_Application.Abstractions.Generic;
using VehicleManagement_Infrastructure;

namespace Permission_Infrastructure.Generic
{
    public class GenericRepositories<T> : IGenericRepositories<T> where T : class
    {
        private readonly AppDbContext _appDbContext;
        private readonly DbSet<T> dbSet;
        public GenericRepositories(AppDbContext app)
        {
            _appDbContext = app;
            dbSet = _appDbContext.Set<T>();
        }
        public async Task<T> CreateAsync(T entity)
        {
            
            try
            {
                var entry = await dbSet.AddAsync(entity);
                await _appDbContext.SaveChangesAsync();
                return entry.Entity;
            }
            catch(Exception  ex)
            {
                throw null;
            }

        }
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var entity = await dbSet.FirstOrDefaultAsync(x => x.Equals(id));
                dbSet.Remove(entity);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch
            {
                throw null;
            }
        }

        public async Task<T> GetAsync(int id)
        {
            try
            {
                var get = await dbSet.FindAsync(id);
                dbSet.Remove(get);
                await _appDbContext.SaveChangesAsync();

                return get;
            }
            catch
            {
                throw null;
            }
        }
        public async Task<T> UpdateAsync(T entity)
        {
            try
            {
                var entry = dbSet.Update(entity);
                await _appDbContext.SaveChangesAsync();
                return entry.Entity;
            }
            catch
            {
                throw null;
            }
        }
    }

}
