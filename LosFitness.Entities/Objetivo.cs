using System.ComponentModel.DataAnnotations;
namespace LosFitness.Entities;

public class Objetivo: EntityBase
{
    public int Id { get; set; }

    [StringLength(30)]
    [Required]
    public string Titulo { get; set; }

    [StringLength(100)]
    [Required]
    public string Describcion { get; set; }

    public bool Check { get; set; }

}