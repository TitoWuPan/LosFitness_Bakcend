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
    public class Horario_ActividadService:IHorario_ActividadService
    {
        private readonly LosFitnessDbContext _context;

        public Horario_ActividadService(LosFitnessDbContext context)
        {
            _context = context;
        }

        public async Task<Horario_Actividad> CreateHorario_Actividad(Horario_Actividad Horario_Actividad)
        {
            await _context.Horario_Actividads.AddAsync(Horario_Actividad);
            await _context.SaveChangesAsync();

            return Horario_Actividad;
        }

        public async Task DeleteHorario_Actividad(Horario_Actividad Horario_Actividad)
        {
            _context.Horario_Actividads.Remove(Horario_Actividad);
            await _context.SaveChangesAsync();
        }

        public async Task<Horario_Actividad> GetHorario_Actividad(int id)
        {
            return await _context.Horario_Actividads.Where(g=>g.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Horario_Actividad>> GetHorario_Actividads()
        {
            return await _context.Horario_Actividads.ToListAsync();
        }

        public async Task UpdateHorario_Actividad(Horario_Actividad Horario_Actividad)
        {
            _context.Entry(Horario_Actividad).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
