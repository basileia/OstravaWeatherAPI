using System.Linq.Expressions;

namespace OstravaWeatherAPI_DAL.Contracts
{
    public interface IRepositoryBase<T>
    {
        List<T> GetAll();
        T GetById(int id);
        T GetByPredicate(Expression<Func<T, bool>> predicate);
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
