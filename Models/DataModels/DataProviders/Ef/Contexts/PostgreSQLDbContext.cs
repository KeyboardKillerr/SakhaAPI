using DataModels.DataProviders.Ef.Core;
using Microsoft.EntityFrameworkCore;

namespace DataModels.DataProviders.Ef.Contexts;

public class PostgreSQLDbContext : DataContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseNpgsql(@"Host=localhost;Port=5432;Database=SakhaDB;Username=postgres;Password=1;TrustServerCertificate=True;");
        //         or Host=external_example.com;
    }
}

