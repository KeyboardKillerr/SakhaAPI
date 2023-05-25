using DataModels.DataProviders.Ef.Core;
using Microsoft.EntityFrameworkCore;

namespace DataModels.DataProviders.Ef.Contexts;

public class PostgreSQLDbContext : DataContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseNpgsql(@"Host=84.237.49.54;Port=5433;Database=PostgreSQL 15;Username=BackendEntry;Password=12345!;TrustServerCertificate=True");
        //         or Host=external_example.com;
    }
}

