using System.ComponentModel.DataAnnotations;
namespace LosFitness.Entities;

public class Horario_Actividad : EntityBase
{
    public int HorarioId { get; set; }
    public Horario Horario { get; set; }

    public int ActividadId { get; set; }
    public Actividad Actividad  { get; set; }

    public DateTime Fecha { get; set; }
}