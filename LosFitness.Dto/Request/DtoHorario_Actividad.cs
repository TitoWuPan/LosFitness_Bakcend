using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosFitness.Dto.Request;

public class DtoHorario_Actividad
{
    public int HorarioId { get; set; }

    public int ActividadId { get; set; }

    public DateTime FechaInicio { get; set; }
    public DateTime FechaFinal { get; set; }
}

