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
    public class GeneresController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GeneresController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet("ff")]
        public async Task<IActionResult> getallgeneres()
        {
            var generes = await _genreService.GetAll();
            return Ok(generes);
        }

        [HttpPost("gg")]
        public async Task<IActionResult> addgenere(GenereDTO g)
        {
            var genere = new Genre { Name = g.name };
            _genreService.AddGenre(genere);
            return Ok(genere);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> update(int id, GenereDTO g)
        {
            var genere = await _genreService.GetbyId(id);

            if (genere == null)
            {
                return NotFound($"no genere with {id}");
            }
            genere.Name = g.name;
            _genreService.Update(genere);
            return Ok(genere);

        }

        [HttpDelete("del/{id}")]
        public async Task<IActionResult> delete(int id)
        {
            var genere = await _genreService.GetbyId(id);

            if (genere == null)
            {
                return NotFound($"no genere with {id}");
            }
            _genreService.DeleteGenre(genere);
            return Ok(genere);

        }
    }
}
