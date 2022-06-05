using System.ComponentModel.DataAnnotations;
namespace LosFitness.Entities;

public class Dieta: EntityBase
{
    public int Id { get; set; }

    [StringLength(30)]
    [Required]
    public string Titulo { get; set; }

    [StringLength(100)]
    [Required]
    public string Describcion { get; set; }

    public int Puntuacion { get; set; }

    public int CatalogoId { get; set; }
    public Catalogo Catalogo { get; set; }

}