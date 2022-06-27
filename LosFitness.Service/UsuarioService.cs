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
    public class UsuarioService:IUsuarioService
    {
        private readonly LosFitnessDbContext _context;

        public UsuarioService(LosFitnessDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> CreateUsuario(Usuario Usuario)
        {
            await _context.Usuarios.AddAsync(Usuario);
            await _context.SaveChangesAsync();

            return Usuario;
        }

        public async Task DeleteUsuario(Usuario Usuario)
        {
            _context.Usuarios.Remove(Usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<Usuario> GetUsuario(int id)
        {
            return await _context.Usuarios.Where(g=>g.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Usuario>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task UpdateUsuario(Usuario Usuario)
        {
            _context.Entry(Usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
