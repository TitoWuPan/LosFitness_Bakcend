using LosFitness.DataAccess;
using LosFitness.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static LosFitness.Dto.Request.BaseResponse;
namespace LosFitness.API.Controllers
{

    [ApiController]
    [Route("api/[Controller]")]

    public class DietaControler:ControllerBase
    {

        private readonly LosFitnessDbContext _context;

        public DietaControler(LosFitnessDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<BaseResponseGeneric<ICollection<Dieta>>>> Get()
        {
            var response = new BaseResponseGeneric<ICollection<Dieta>>();

            try
            {
                response.Result = await _context.Dietas.ToListAsync();
                response.Success = true;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Errors.Add(ex.Message);
                return response;

            }

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Dieta>> Get(int id)
        {
            var entity = await _context.Dietas.FindAsync(id);
            if (entity == null)
            {
                return NotFound("No se encontró el registro");
            }

            return Ok(entity);
        }

        [HttpPost("Registro")]
        public async Task<ActionResult> Post(Dto.Request.DtoDieta request)
        {
            var entity = new Dieta
            {
                Titulo =request.Titulo,
                Describcion = request.Describcion,
                Puntuacion=request.Puntuacion,
                CatalogoId=request.CatalogoId,
            };

            _context.Dietas.Add(entity);
            await _context.SaveChangesAsync();

            HttpContext.Response.Headers.Add("location", $"/api/usuario/{entity.Id}*");

            return Ok();
        }

  
        [HttpDelete("Eliminar Cuenta/{id:int}")]
        public async Task<ActionResult<Dieta>> Delete(int id)
        {
            var entity = await _context.Dietas.FindAsync(id);
            if (entity == null)
            {
                return NotFound("No se encontró el usuario");
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
