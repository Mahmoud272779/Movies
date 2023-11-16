using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies.DTOs;
using Movies.Models;
using Movies.Services;

namespace Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private IMovieService _movieService;
        private IGenreService _genreService;
        private List<string> _AllowedExtensions = new List<string> {".jpg",".png" };

        private long _maxAllowedPostarSize = 1024 * 1024;

        public MovieController(IMovieService movieService, IGenreService genreService)
        {

            _movieService = movieService;
            _genreService = genreService;
        }



        [HttpGet("ff")]
        public async Task<IActionResult> getallmovies()
        {
            var movies =  await _movieService.GetAll();
            return Ok(movies.Select(m=>new { 
            MovieID=m.Id,
            GenereID=m.genre.Id,
            GenereName=m.genre.Name,
            Rate=m.rate

            }).ToList());
        }





        [HttpPost("gg")]
        public async Task<IActionResult> addmovie([FromForm] MovieDTO m)
        {
            if (!_AllowedExtensions.Contains(Path.GetExtension(m.postar.FileName).ToLower()))
                return BadRequest("Only png and jpg");

            if (m.postar.Length > _maxAllowedPostarSize)
                return BadRequest("Max allowed size for poster is 1MB!");

            if (!_genreService.isvalidgenre( m.GenreId))
                return BadRequest("GenreId is not in Genre table!");

            using var datastream = new MemoryStream();

            m.postar.CopyTo(datastream);
            var movie = new Movie
            {
                GenreId = m.GenreId,
                postar = datastream.ToArray(),
                rate = m.rate,
                Title = m.Title,
                storeline = m.storeline,
                year = m.year,
            };
            _movieService.addmovie(movie);
            return Ok(movie);
        }





        [HttpGet("getById/{id}")]
        public async Task<IActionResult> getbyid(int id)
        {
            var movie =  await _movieService.getbyid(id);

            if (movie == null)
                return NotFound("Not found");
            return Ok(new
            {
                name = movie.Title,
                postar = movie.postar
            });
        }

        [HttpGet("getByGenreId/{id}")]
        public async Task<IActionResult> getbygenreid(int id)
        {
            var movies = await _movieService.getbygenreid(id);



            if (movies == null)
                return NotFound("Not found");
            return Ok(movies.Select(m => new { m.GenreId, m.Title }).ToList()
           );
        }

        [HttpDelete("Delmovie/{id}")]
        public async Task<IActionResult> Delmovie(int id)
        {
            var movie = await _movieService.getbyid(id);



            if (movie == null)
                return NotFound("Not found");

             _movieService.delmovie(movie);
            return Ok(movie
           );
        }
    }
}
