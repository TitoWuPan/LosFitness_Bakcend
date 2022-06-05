using System.ComponentModel.DataAnnotations;
namespace LosFitness.Entities;

public class Recompesa_Usuario: EntityBase
{
    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; }

    public int RecompensaId { get; set; }
    public Recompensa Recompensa { get; set; }

}