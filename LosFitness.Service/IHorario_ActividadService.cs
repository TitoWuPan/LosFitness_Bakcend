using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LosFitness.Entities;

namespace LosFitness.Service
{
    public interface IHorario_ActividadService
    {
        Task<Horario_Actividad> CreateHorario_Actividad(Horario_Actividad Horario_Actividad);

        Task DeleteHorario_Actividad(Horario_Actividad Horario_Actividad);

        Task<Horario_Actividad> GetHorario_Actividad(int id);

        Task<List<Horario_Actividad>> GetHorario_Actividads();

        Task UpdateHorario_Actividad(Horario_Actividad Horario_Actividad);
    }
}
