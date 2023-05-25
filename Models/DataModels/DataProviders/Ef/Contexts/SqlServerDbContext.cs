using DataModels.DataProviders.Ef.Core;
using Microsoft.EntityFrameworkCore;

namespace DataModels.DataProviders.Ef.Contexts;

public class SqlServerDbContext : DataContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseSqlServer(@"Data Source = DESKTOP-P105T05; Initial Catalog = SahaDB; Integrated Security = True; TrustServerCertificate=True");
    }
}

