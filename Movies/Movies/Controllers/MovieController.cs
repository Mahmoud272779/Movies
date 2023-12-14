using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies.DTOs;
using Movies.Models;
using Movies.Repository;
using Movies.Services;

namespace Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        //private imovieservice _movieservice;
        //private igenreservice _genreservice;
        //private IBaseRepo<Movie> _movieRepo;

        private readonly IUnitOfWork unitOfWork;

        public MovieController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        private List<string> _AllowedExtensions = new List<string> {".jpg",".png" };

        private long _maxAllowedPostarSize = 1024 * 1024;

        



        [HttpGet("ff")]
        public async Task<IActionResult> getallmovies()
        {
            var movies =  await unitOfWork.MovieRepo.GetAll();
            return Ok(movies.Select(m=>new { 
            MovieID=m.Id,
           
            Rate=m.rate,

            poster=m.postar

            }).ToList());
        }





        [HttpPost("gg")]
        public async Task<IActionResult> addmovie([FromForm] MovieDTO m)
        {
            if (!_AllowedExtensions.Contains(Path.GetExtension(m.postar.FileName).ToLower()))
                return BadRequest("Only png and jpg");

            if (m.postar.Length > _maxAllowedPostarSize)
                return BadRequest("Max allowed size for poster is 1MB!");

           // if (!_movierepo.isvalidgenre( m.genreid))
              //  return badrequest("genreid is not in genre table!");

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
            unitOfWork.MovieRepo.Add(movie);
            unitOfWork.Commit();
            return Ok(movie);
        }





        [HttpGet("getById/{id}")]
        public async Task<IActionResult> getbyid(int id)
        {
            var movie = await unitOfWork.MovieRepo.GetbyId<int>(id);

            if (movie == null)
                return NotFound("Not found");
            return Ok(new
            {
                name = movie.Title,
                postar = movie.postar
            });
        }
        //git remote add origin https://github.com/Mahmoud272779/ERP_system.git

        //[httpget("getbygenreid/{id}")]
        //public async task<iactionresult> getbygenreid(int id)
        //{
        //    var movies = await _movieservice.getbygenreid(id);



        //    if (movies == null)
        //        return notfound("not found");
        //    return ok(movies.select(m => new { m.genreid, m.title }).tolist()
        //   );
        //}

        [HttpDelete("Delmovie/{id}")]
        public async Task<IActionResult> Delmovie(int id)
        {
            var movie = await unitOfWork.MovieRepo.GetbyId(id);



            if (movie == null)
                return NotFound("Not found");

            unitOfWork.MovieRepo.DeleteGenre(movie);
            unitOfWork.Commit();
            return Ok(movie
           );
        }
    }
}
