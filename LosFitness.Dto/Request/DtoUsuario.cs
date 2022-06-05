using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosFitness.Dto.Request;

public class DtoUsuario
{
    public string Nombre { get; set; }

    public string Apellido { get; set; }

    public string Genero { get; set; }

    public int Peso { get; set; }

    public bool Premiun { get; set; }

    public string? ImageURL { get; set; }
}
