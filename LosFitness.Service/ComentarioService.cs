using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LosFitness.DataAccess;
using LosFitness.Entities;
using Microsoft.EntityFrameworkCore;

namespace LosFitness.Service
{
    public class ComentarioService:IComentarioService
    {
        private readonly LosFitnessDbContext _context;

        public ComentarioService(LosFitnessDbContext context)
        {
            _context = context;
        }

        public async Task<Comentario> CreateComentario(Comentario Comentario)
        {
            await _context.Comentarios.AddAsync(Comentario);
            await _context.SaveChangesAsync();

            return Comentario;
        }

        public async Task DeleteComentario(Comentario Comentario)
        {
            _context.Comentarios.Remove(Comentario);
            await _context.SaveChangesAsync();
        }

        public async Task<Comentario> GetComentario(int id)
        {
            return await _context.Comentarios.Where(g=>g.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Comentario>> GetComentarios()
        {
            return await _context.Comentarios.ToListAsync();
        }

        public async Task UpdateComentario(Comentario Comentario)
        {
            _context.Entry(Comentario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
