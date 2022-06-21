using LosFitness.DataAccess;
using LosFitness.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosFitness.Service
{
    public class UsuarioService:IUsuarioService
    {
        private readonly LosFitnessDbContext _context;

        public UsuarioService(LosFitnessDbContext context)
        {
            this._context = context;
        }

        public async Task<Usuario> CreateGenre(Usuario genre)
        {
            await _context.Usuarios.AddAsync(genre);
            await _context.SaveChangesAsync();

            return genre;
        }

        public async Task DeleteGenre(Usuario genre)
        {
            _context.Usuarios.Remove(genre);
            await _context.SaveChangesAsync();
        }

        public async Task<Usuario> GetGenre(int id)
        {
            return await _context.Usuarios.Where(g => g.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Usuario>> GetGenres()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task UpdateGenre(Usuario genre)
        {
            _context.Entry(genre).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
    
}
