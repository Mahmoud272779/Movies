using Microsoft.AspNetCore.Mvc;
using Movies.Models;

namespace Movies.Services
{
    public interface IMovieService
    {
        public Task<IEnumerable<Movie>> GetAll();

        public Task<Movie> getbyid(int id);

        public Task<Movie> addmovie(Movie movie);

        public Task<IEnumerable<Movie>> getbygenreid(int id);

        public Task<Movie> delmovie(Movie movie);

    }
}
