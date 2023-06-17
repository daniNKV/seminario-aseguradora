using Aplicacion.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Repositorios.Database;

public class AseguradoraContexto : DbContext
{
    #nullable disable
    public DbSet<Titular> Titulares { get; set; }
    public DbSet<Poliza> Polizas { get; set; }
    public DbSet<Vehiculo> Vehiculos { get; set; }
    public DbSet<Siniestro> Siniestros { get; set; }
    public DbSet<Tercero> Terceros { get; set; }
    #nullable restore
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("data source=Aseguradora.sqlite");
    }
/*
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
*/
}
