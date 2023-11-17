namespace DemoEF8.Models;

public class CustomersDbContext: DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "Server=(localdb)\\mssqllocaldb;Database=DemoEF8;Trusted_Connection=True;MultipleActiveResultSets=true";

        optionsBuilder.UseSqlServer(connectionString)
            .EnableSensitiveDataLogging()
            .LogTo(Console.WriteLine, LogLevel.Information);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>()
            .OwnsOne(c => c.Details, d =>
            {
                d.OwnsMany(x => x.Addresses);
                d.OwnsMany(x => x.Phones);
                d.ToJson();
            });
    }

    public DbSet<Customer> Customers { get; set; }

}
