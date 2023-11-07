using Application.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class EfRepository : IRepository
    {
        private readonly DbContext _dbContext;

        public EfRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T Add<T>(T entity) where T : class
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public void Delete<T>(T entity) where T : class
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public List<T> Get<T>(Expression<Func<T, bool>> condition) where T : class
        {
            return _dbContext.Set<T>().Where(condition).AsNoTracking().ToList();
        }

        public List<T> GetAll<T>() where T : class
        {
            return _dbContext.Set<T>().AsNoTracking().ToList();
        }

        public async Task<List<T>> GetAllAsync<T>() where T : class
        {
            return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<List<T>> GetAsync<T>(Expression<Func<T, bool>> condition) where T : class
        {
            return await _dbContext.Set<T>().Where(condition).AsNoTracking().ToListAsync();
        }

        public T GetSingle<T>(Expression<Func<T, bool>> condition) where T : class
        {
            return _dbContext.Set<T>().AsNoTracking().SingleOrDefault(condition);
        }

        public async Task<T> GetSingleAsync<T>(Expression<Func<T, bool>> condition) where T : class
        {
            return await _dbContext.Set<T>().AsNoTracking().SingleOrDefaultAsync(condition);
        }

        public void Update<T>(T entity) where T : class
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
