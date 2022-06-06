using LosFitness.DataAccess;
using LosFitness.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LosFitness.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CatalogoControler : ControllerBase
    {
        private readonly LosFitnessDbContext _context;

        public CatalogoControler(LosFitnessDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult> Post(Dto.Request.DtoCatalogo request)
        {
            var entity = new Catalogo
            {
                Titulo = request.Titulo

            };
            //
            _context.Catalogos.Add(entity);
            await _context.SaveChangesAsync();

            HttpContext.Response.Headers.Add("location", $"/api/actividad/{entity.Id}*");

            return Ok();
        }

        //httpstatus van en categoriashttps://developer.mozilla.org/es/docs/Web/HTTP/Status 
        [HttpGet]//
        public async Task<ActionResult<ICollection<Catalogo>>> Get()
        {//
            ICollection<Catalogo> response;

            response = await _context.Catalogos.ToListAsync();

            return Ok(response);
        }
        ///get id
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Catalogo>> Get(int id)
        {
            var entity = await _context.Catalogos.FindAsync(id);
            if (entity == null)
            {
                return NotFound("No se encontró el registro");
            }

            return Ok(entity);
        }
        ///put id
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Dto.Request.DtoCatalogo request)
        {
            var entity = await _context.Catalogos.FindAsync(id);

            if (entity == null) return NotFound();

            entity.Titulo = request.Titulo;

            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(new { Id = id });
        }
        ///delete

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Catalogo>> Delete(int id)
        {
            var entity = await _context.Catalogos.FindAsync(id);
            if (entity == null)
            {
                return NotFound("No se encontró el registro");
            }
            else
            {
                _context.Catalogos.Remove(entity);
                _context.SaveChanges();
                return Ok();
            }

            return Ok(entity);
        }

    }
}
