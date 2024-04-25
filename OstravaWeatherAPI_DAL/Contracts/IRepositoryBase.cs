namespace OstravaWeatherAPI_DAL.Contracts
{
    public interface IRepositoryBase<T>
    {
        List<T> GetAll();
        T GetById(int id);
        T GetByDate(DateOnly date);
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
