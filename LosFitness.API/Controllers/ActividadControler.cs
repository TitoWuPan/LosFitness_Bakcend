using LosFitness.DataAccess;
using LosFitness.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static LosFitness.Dto.Request.BaseResponse;

namespace LosFitness.API.Controllers
{
    [ApiController]
    [Route("api/Controllers")]
    public class ActividadControler : ControllerBase
    {
        private readonly LosFitnessDbContext _context;

        public ActividadControler(LosFitnessDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<BaseResponseGeneric<ICollection<Actividad>>>> Get()
        {
            var response = new BaseResponseGeneric<ICollection<Actividad>>();

            try
            {
                response.Result = await _context.Actividads.ToListAsync();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Errors.Add(ex.Message);
                throw;
            }

            return Ok(Response);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Actividad>> Get(int id)
        {
            var entity = await _context.Actividads.FindAsync(id);
            if (entity == null)
            {
                return NotFound("No se encontró el registro");
            }

            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Dto.Request.DtoActividad request)
        {
            var entity = new Actividad
            {
                Titulo = request.Titulo,
                Describcion = request.Describcion,
                Status = true
            };

                _context.Actividads.Add(entity);
                await _context.SaveChangesAsync();

                HttpContext.Response.Headers.Add("location", $"/api/Actividad/{entity.Id}*");

            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Dto.Request.DtoActividad request)
        {
            var entity = await _context.Actividads.FindAsync(id);

            if (entity == null) return NotFound();

            entity.Titulo = request.Titulo;
            entity.Describcion = request.Describcion;

            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(new { Id = id });
        }

    }
}
