using Movies.Models;

namespace Movies.Repository
{
    public interface IUnitOfWork :IDisposable
    {
        void Commit();
         IBaseRepo<Genre> GenreRepo { get; }
         IBaseRepo<Movie> MovieRepo { get; }

    }
}
