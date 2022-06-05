using System.ComponentModel.DataAnnotations;
namespace LosFitness.Entities;

public class Horario: EntityBase
{
    public int Id { get; set; }

    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; }

    public int DietaId { get; set; }
    public Dieta Dieta { get; set; }

}