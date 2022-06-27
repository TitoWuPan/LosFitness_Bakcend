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
    public class CatalogoService:ICatalogoService
    {
        private readonly LosFitnessDbContext _context;

        public CatalogoService(LosFitnessDbContext context)
        {
            _context = context;
        }

        public async Task<Catalogo> CreateCatalogo(Catalogo Catalogo)
        {
            await _context.Catalogos.AddAsync(Catalogo);
            await _context.SaveChangesAsync();

            return Catalogo;
        }

        public async Task DeleteCatalogo(Catalogo Catalogo)
        {
            _context.Catalogos.Remove(Catalogo);
            await _context.SaveChangesAsync();
        }

        public async Task<Catalogo> GetCatalogo(int id)
        {
            return await _context.Catalogos.Where(g=>g.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Catalogo>> GetCatalogos()
        {
            return await _context.Catalogos.ToListAsync();
        }

        public async Task UpdateCatalogo(Catalogo Catalogo)
        {
            _context.Entry(Catalogo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
