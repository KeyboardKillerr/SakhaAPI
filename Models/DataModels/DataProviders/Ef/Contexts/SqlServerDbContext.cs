using DataModels.DataProviders.Ef.Core;
using Microsoft.EntityFrameworkCore;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataModels.DataProviders.Ef.Contexts;

public class SqlServerDbContext : DataContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseSqlServer(@"Data Source = DESKTOP-P105T05; Initial Catalog = SakhaDB; Integrated Security = True; TrustServerCertificate=True");
    }
}

