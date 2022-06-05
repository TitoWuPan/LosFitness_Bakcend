using System.ComponentModel.DataAnnotations;
namespace LosFitness.Entities;

public class Alimento_Dieta: EntityBase
{
    public int AliementoId { get; set; }
    public Alimento Alimento { get; set; }

    public int DietaId { get; set; }
    public Dieta Dieta { get; set; }

}