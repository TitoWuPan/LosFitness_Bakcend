using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosFitness.Dto.Request;

public class DtoDieta
{
    public string Titulo { get; set; }

    public string Describcion { get; set; }

    public int Puntuacion { get; set; }

    public int CatalogoId { get; set; }
}
