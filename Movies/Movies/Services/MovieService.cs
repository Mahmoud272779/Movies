using Microsoft.EntityFrameworkCore;
using Movies.Models;

namespace Movies.Services
{
    public class MovieService : IMovieService
    {
        private readonly ApplicationDBContext _db;

        public MovieService(ApplicationDBContext db)
        {
            _db = db;
        }

        public async Task<Movie> addmovie(Movie movie)
        {
            _db.Movies.Add(movie);
            _db.SaveChanges();
            return movie;
        }

        public async Task<Movie> delmovie(Movie movie)
        {
            _db.Remove(movie);

            _db.SaveChanges();

            return movie;
        }

        public async Task<IEnumerable<Movie>> GetAll()
        {
            var movies = _db.Movies.Include(m => m.genre).OrderByDescending(x => x.rate);
            return movies.ToList();

            
        }

        public async Task<IEnumerable<Movie>> getbygenreid(int id)
        {
          return  _db.Movies.Include(m => m.genre).Where(m => m.genre.Id == id);
        }

        public async Task<Movie> getbyid(int id)
        {
          var movie=  _db.Movies.SingleOrDefault(m => m.Id == id);
            return movie;
        }
    }
}
