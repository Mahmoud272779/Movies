using Movies.Models;

namespace Movies.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _db;
        public UnitOfWork(ApplicationDBContext db )
        {
            _db = db;
            GenreRepo = new BaseRepo<Genre>(_db);
            MovieRepo = new BaseRepo<Movie>(_db);
        }

      

      public  IBaseRepo<Genre> GenreRepo { set; get; }

     public   IBaseRepo<Movie> MovieRepo  { set; get; }

        public void Commit()
        {
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
