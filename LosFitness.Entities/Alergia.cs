﻿using System.ComponentModel.DataAnnotations;
namespace LosFitness.Entities;

public class Alergia: EntityBase
{
    public int AliementoId { get; set; }
    public Alimento Alimento { get; set; }

    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; }

}