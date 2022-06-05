using System.ComponentModel.DataAnnotations;
namespace LosFitness.Entities;

public class Alimento : EntityBase
{
    public int Id { get; set; }

    [StringLength(30)]
    [Required]
    public string Nombre { get; set; }

}