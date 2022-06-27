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
    public class Recompesa_UsuarioService:IRecompesa_UsuarioService
    {
        private readonly LosFitnessDbContext _context;

        public Recompesa_UsuarioService(LosFitnessDbContext context)
        {
            _context = context;
        }

        public async Task<Recompesa_Usuario> CreateRecompesa_Usuario(Recompesa_Usuario Recompesa_Usuario)
        {
            await _context.Recompesa_Usuarios.AddAsync(Recompesa_Usuario);
            await _context.SaveChangesAsync();

            return Recompesa_Usuario;
        }

        public async Task DeleteRecompesa_Usuario(Recompesa_Usuario Recompesa_Usuario)
        {
            _context.Recompesa_Usuarios.Remove(Recompesa_Usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<Recompesa_Usuario> GetRecompesa_Usuario(int id)
        {
            return await _context.Recompesa_Usuarios.Where(g=>g.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Recompesa_Usuario>> GetRecompesa_Usuarios()
        {
            return await _context.Recompesa_Usuarios.ToListAsync();
        }

        public async Task UpdateRecompesa_Usuario(Recompesa_Usuario Recompesa_Usuario)
        {
            _context.Entry(Recompesa_Usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
