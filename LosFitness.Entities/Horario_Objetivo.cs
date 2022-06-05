using System.ComponentModel.DataAnnotations;
namespace LosFitness.Entities;

public class Horario_Objetivo : EntityBase
{
    public int HorarioId { get; set; }
    public Horario Horario { get; set; }

    public int ObjetivoId { get; set; }
    public Objetivo Objetivo { get; set; }
}