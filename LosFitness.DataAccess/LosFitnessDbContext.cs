using LosFitness.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace LosFitness.DataAccess;

public class LosFitnessDbContext : DbContext
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public LosFitnessDbContext()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {

    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public LosFitnessDbContext(DbContextOptions<LosFitnessDbContext> options):base(options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
            
    }

    public DbSet<Actividad> Actividades { get; set; }
    public DbSet<Alergia> Alergias { get; set; }
    public DbSet<Alimento> Alimentos { get; set; }
    public DbSet<Alimento_Dieta> Alimento_Dietas { get; set; }
    public DbSet<Catalogo> Catalogos { get; set; }
    public DbSet<Comentario> Comentarios { get; set; }
    public DbSet<Dieta> Dietas { get; set; }
    public DbSet<Horario> Horarios { get; set; }
    public DbSet<Horario_Actividad> Horario_Actividades { get; set; }
    public DbSet<Horario_Objetivo> Horario_Objetivos { get; set; }
    public DbSet<Objetivo> Objetivos { get; set; }
    public DbSet<Recompensa> Recompensas { get; set; }
    public DbSet<Recompesa_Usuario> Recompesa_Usuarios { get; set; }
    public DbSet<Plan> Plans { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

}