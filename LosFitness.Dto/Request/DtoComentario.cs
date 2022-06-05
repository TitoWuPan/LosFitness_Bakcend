using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosFitness.Dto.Request;

public class DtoComentario
{
    public int UsuarioId { get; set; }
    public int DietaId { get; set; }
    public string Comentariotexto { get; set; }
}

