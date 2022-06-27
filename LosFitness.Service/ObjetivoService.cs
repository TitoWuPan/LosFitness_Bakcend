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
    public class ObjetivoService:IObjetivoService
    {
        private readonly LosFitnessDbContext _context;

        public ObjetivoService(LosFitnessDbContext context)
        {
            _context = context;
        }

        public async Task<Objetivo> CreateObjetivo(Objetivo Objetivo)
        {
            await _context.Objetivos.AddAsync(Objetivo);
            await _context.SaveChangesAsync();

            return Objetivo;
        }

        public async Task DeleteObjetivo(Objetivo Objetivo)
        {
            _context.Objetivos.Remove(Objetivo);
            await _context.SaveChangesAsync();
        }

        public async Task<Objetivo> GetObjetivo(int id)
        {
            return await _context.Objetivos.Where(g=>g.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Objetivo>> GetObjetivos()
        {
            return await _context.Objetivos.ToListAsync();
        }

        public async Task UpdateObjetivo(Objetivo Objetivo)
        {
            _context.Entry(Objetivo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
