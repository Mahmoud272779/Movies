using Movies.Models;

namespace Movies.Services
{
    public interface IGenreService
    {
        public  Task<IEnumerable<Genre>> GetAll();
        public Task <Genre> AddGenre(Genre g);

         public Task<Genre> GetbyId(int id);

        public Genre DeleteGenre(Genre g);

        public Genre Update(Genre g);

        public bool isvalidgenre(int id);
    }
}
