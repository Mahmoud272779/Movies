using Movies.Models;

namespace Movies.Repository
{
    public interface IBaseRepo<T> where T : class
    {
        public  Task<T> Add(T t);
        public Task<T> GetbyId<y>(y id);
        public  Task<IEnumerable<T>> GetAll();
        public T Update(T g);

        T DeleteGenre(T g);
    }
}
