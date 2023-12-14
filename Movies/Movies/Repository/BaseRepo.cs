using Movies.Models;

namespace Movies.Repository
{
    public class BaseRepo<T> : IBaseRepo<T> where T : class
    {
        private readonly ApplicationDBContext _dbContext;

        public BaseRepo(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> Add(T t)
        {
           _dbContext.Set<T>().Add(t);
            
            return t;
        }

        public T DeleteGenre(T g)
        {
            _dbContext.Remove(g);
            return g;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public async Task<T> GetbyId<y>(y id)
        {
           
           return  _dbContext.Set<T>().Find(id);
        }

       

        public T Update(T g)
        {
            _dbContext.Set<T>().Update(g);
            return g;
        }
    }
}
