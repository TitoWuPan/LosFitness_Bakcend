using System.ComponentModel.DataAnnotations;
namespace LosFitness.Entities;

public class Usuario : EntityBase
{
    public int Id { get; set; }

    [StringLength(25)]
    [Required]
    public string Nombre { get; set; }

    [StringLength(25)]
    [Required]
    public string Apellido { get; set; }

    [StringLength(25)]
    [Required]
    public string Genero { get; set; }

    public bool Premiun { get; set; }

    public string? ImageURL { get; set; }

}