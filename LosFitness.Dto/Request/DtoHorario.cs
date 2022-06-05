using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosFitness.Dto.Request;

public class DtoHorario
{
    public int UsuarioId { get; set; }

    public int DietaId { get; set; }

    public DateTime Inicio { get; set; }
    public DateTime Fin { get; set; }

}