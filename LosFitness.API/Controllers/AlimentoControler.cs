using LosFitness.DataAccess;
using LosFitness.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static LosFitness.Dto.Request.BaseResponse;

namespace LosFitness.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AlimentoControler : ControllerBase
    {
        private readonly LosFitnessDbContext _context;

        public AlimentoControler(LosFitnessDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<BaseResponseGeneric<ICollection<Alimento>>>> Get()
        {
            var response = new BaseResponseGeneric<ICollection<Alimento>>();

            try
            {
                response.Result = await _context.Alimentos.ToListAsync();
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
        public async Task<ActionResult<Alimento>> Get(int id)
        {
            var entity = await _context.Alimentos.FindAsync(id);
            if (entity == null)
            {
                return NotFound("No se encontró el registro");
            }

            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Dto.Request.DtoAlimento request)
        {
            var entity = new Alimento
            {
                Nombre = request.Nombre,
                 Status=true,
            };

            _context.Alimentos.Add(entity);
            await _context.SaveChangesAsync();

            HttpContext.Response.Headers.Add("location", $"/api/alimento/{entity.Id}*");

            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Dto.Request.DtoAlimento request)
        {
            var entity = await _context.Alimentos.FindAsync(id);

            if (entity == null) return NotFound();

            entity.Nombre = request.Nombre;
           
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(new { Id = id });
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Alimento>> Delete(int id)
        {
            var entity = await _context.Alimentos.FindAsync(id);
            if (entity == null)
            {
                return NotFound("No se encontró el registro");
            }
            else
            {
                _context.Alimentos.Remove(entity);
                _context.SaveChanges();
                return Ok();
            }

            return Ok(entity);
        }
    }
}
