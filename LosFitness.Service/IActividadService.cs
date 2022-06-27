using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LosFitness.Entities;

namespace LosFitness.Service
{
    public interface IActividadService
    {
        Task<Actividad> CreateActividad(Actividad actividad);

        Task DeleteActividad(Actividad actividad);

        Task<Actividad> GetActividad(int id);

        Task<List<Actividad>> GetActividads();

        Task UpdateActividad(Actividad actividad);
    }
}
