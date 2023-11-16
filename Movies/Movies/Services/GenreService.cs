using Microsoft.EntityFrameworkCore;
using Movies.Models;

namespace Movies.Services
{
    public class GenreService : IGenreService
    {

        private readonly ApplicationDBContext _db;

        public GenreService(ApplicationDBContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Genre>> GetAll()
        {
            var generes = await _db.Generes.ToListAsync();


            return generes;
        }


        public async Task<Genre> AddGenre(Genre g)
        {
            _db.Generes.Add(g);
            _db.SaveChanges();

            return g;
        }



        public async Task<Genre> GetbyId(int id)
        {
            return _db.Generes.SingleOrDefault(f => f.Id == id);
        }

        public Genre Update(Genre g)
        {
            _db.Generes.Update(g);
            _db.SaveChangesAsync();
            return g;
        }

        Genre IGenreService.DeleteGenre(Genre g)
        {
            _db.Generes.Remove(g);
            _db.SaveChanges();
            return g;
        }

        public bool isvalidgenre(int id)
        {
            return (_db.Generes.Any(g => g.Id == id)) ;
               
        }
    }
}