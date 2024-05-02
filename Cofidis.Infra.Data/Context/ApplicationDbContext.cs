using Cofidis.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cofidis.Infra.Data.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
    { }

    public DbSet<CreditLimits> CreditLimit { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        builder.Entity<CreditLimits>()
            .HasNoKey()
            .ToView("CalculateCreditLimit");
    }
}