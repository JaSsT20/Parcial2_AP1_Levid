using Microsoft.EntityFrameworkCore;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options)
    {
        
    }

    public DbSet<Productos> Productos { get; set; }
    public DbSet<Empacado> Empacados { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Productos>().HasData(
            new Productos{
                ProductoId = 1,
                Descripcion = "Mani",
                Costo = 2000,
                Precio = 2600,
                Existencia = 200
            },
            new Productos{
                ProductoId = 2,
                Descripcion = "Pistachos",
                Costo = 3000,
                Precio = 3600,
                Existencia = 400
            },
            new Productos{
                ProductoId = 3,
                Descripcion = "Pasas",
                Costo = 1500,
                Precio = 2000,
                Existencia = 100
            },
            new Productos{
                ProductoId = 4,
                Descripcion = "Ciruela",
                Costo = 4000,
                Precio = 5600,
                Existencia = 700
            }
        );
    }
}