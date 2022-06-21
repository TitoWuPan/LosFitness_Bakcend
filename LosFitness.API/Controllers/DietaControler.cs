using LosFitness.DataAccess;
using LosFitness.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace LosFitness.API.Controllers
{





    [ApiController]
    [Route("api/[Controller]")]
    public class DietaControler : ControllerBase
    {



        private readonly LosFitnessDbContext _context;




        [HttpPost]
        public async Task<ActionResult> Post(Dto.Request.DtoDieta request)
        {
            var entity = new Dieta
            {
                Titulo = request.Titulo,
                Describcion = request.Describcion,
                Puntuacion = request.Puntuacion,
                CatalogoId = request.CatalogoId,

            };

            _context.Dietas.Add(entity);
            await _context.SaveChangesAsync();

            HttpContext.Response.Headers.Add("location", $"/api/Dieta/{entity.Id}*");

            return Ok();
        }


        public DietaControler(LosFitnessDbContext context)
        {
            _context = context;
        }

        [HttpDelete("Eliminar Dieta/{id:int}")]
        public async Task<ActionResult<Usuario>> Delete(int id)
        {
            var entity = await _context.Dietas.FindAsync(id);
            if (entity == null)
            {
                return NotFound("No se encontró la dieta");
            }
            else
            {
                _context.Dietas.Remove(entity);
                _context.SaveChanges();
                return Ok();
            }

            return Ok(entity);
        }
    }
}