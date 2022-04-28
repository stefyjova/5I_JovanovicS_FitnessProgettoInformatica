using Microsoft.EntityFrameworkCore;
public class DbEsercizi : DbContext
{
    public DbSet<Esercizio> Esercizi { get; set; }

    public DbSet<Muscolo> Muscoli { get; set; }
    
    public DbEsercizi(DbContextOptions<DbEsercizi> options) : base(options)
    {
    }
}