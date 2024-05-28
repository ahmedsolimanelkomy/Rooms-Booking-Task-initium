using System.Linq.Expressions;

namespace Rooms_Booking.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(string? includeprop = null);
        T Get(Expression<Func<T, bool>> filter, string? includeprop = null);
        void Add(T entity);
        void Update(T entity);
        void Save();
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        IEnumerable<T> GetList(Expression<Func<T, bool>> filter, string? includeprop = null);
    }
}
