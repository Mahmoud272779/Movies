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
    public class GeneresController : ControllerBase
    { 
       private readonly IUnitOfWork unitOfWork;

        public GeneresController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

       

        [HttpGet("ff")]
        public async Task<IActionResult> getallgeneres()
        {
            var generes = await unitOfWork.GenreRepo.GetAll();
            return Ok(generes);
        }

        [HttpPost("gg")]
        public async Task<IActionResult> addgenere(GenereDTO g)
        {
            var genere = new Genre { Name = g.name };
            unitOfWork.GenreRepo.Add(genere);
            unitOfWork.Commit();
            return Ok(genere);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> update(byte id, GenereDTO g)
        {
            var genere = await unitOfWork.GenreRepo.GetbyId<byte>(id);

            if (genere == null)
            {
                return NotFound($"no genere with {id}");
            }
            genere.Name = g.name;
            unitOfWork.GenreRepo.Update(genere);
            unitOfWork.Commit();
            return Ok(genere);

        }

        [HttpDelete("del/{id}")]
        public async Task<IActionResult> delete(byte id)
        {
            var genere = await unitOfWork.GenreRepo.GetbyId<byte>(id);

            if (genere == null)
            {
                return NotFound($"no genere with {id}");
            }
            unitOfWork.GenreRepo.DeleteGenre(genere);
            unitOfWork.Commit();
            return Ok(genere);

        }
    }
}
