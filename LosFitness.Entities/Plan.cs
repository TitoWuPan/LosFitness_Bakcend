using System.ComponentModel.DataAnnotations;
namespace LosFitness.Entities;

public class Plan: EntityBase
{
    public int Id { get; set; }
    public DateTime Inicio { get; set; }
    public DateTime Fin { get; set; }
    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; }
}