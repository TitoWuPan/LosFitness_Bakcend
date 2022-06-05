using System.ComponentModel.DataAnnotations;
namespace LosFitness.Entities;

public class Catalogo : EntityBase
{
    public int Id { get; set; }

    [StringLength(30)]
    [Required]
    public string Titulo { get; set; }


}