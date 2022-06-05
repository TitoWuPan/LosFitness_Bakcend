using System.ComponentModel.DataAnnotations;
namespace LosFitness.Entities;

public class Comentario : EntityBase
{

    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; }

    public int DietaId { get; set; }
    public Dieta Dieta { get; set; }

    [StringLength(100)]
    [Required]
    public string Comentariotexto { get; set; }

}