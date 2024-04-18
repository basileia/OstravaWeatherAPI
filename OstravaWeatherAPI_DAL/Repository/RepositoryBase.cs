using Microsoft.EntityFrameworkCore;
using OstravaWeatherAPI_DAL.Contracts;
using OstravaWeatherAPI_DAL.Data;
using System.Linq.Expressions;

namespace OstravaWeatherAPI_DAL.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public RepositoryBase(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }
        
        public bool EntityExists(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Any(predicate);
        }

        public List<T> GetAll()
        {

            return _dbSet.ToList();
        }

        public T Add(T entity)
        {
            var obj = _context.Add(entity);
            _context.SaveChanges();
            return obj.Entity;
        }

        public void Update(T entity)
        {
            _context.ChangeTracker.Clear();
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }
    }
}
