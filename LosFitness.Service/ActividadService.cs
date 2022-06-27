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
    public class ActividadService:IActividadService
    {
        private readonly LosFitnessDbContext _context;

        public ActividadService(LosFitnessDbContext context)
        {
            _context = context;
        }

        public async Task<Actividad> CreateActividad(Actividad actividad)
        {
            await _context.Actividads.AddAsync(actividad);
            await _context.SaveChangesAsync();

            return actividad;
        }

        public async Task DeleteActividad(Actividad actividad)
        {
            _context.Actividads.Remove(actividad);
            await _context.SaveChangesAsync();
        }

        public async Task<Actividad> GetActividad(int id)
        {
            return await _context.Actividads.Where(g=>g.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Actividad>> GetActividads()
        {
            return await _context.Actividads.ToListAsync();
        }

        public async Task UpdateActividad(Actividad actividad)
        {
            _context.Entry(actividad).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
