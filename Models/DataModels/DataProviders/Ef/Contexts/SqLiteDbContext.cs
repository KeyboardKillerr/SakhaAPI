﻿using DataModels.DataProviders.Ef.Core;
using Microsoft.EntityFrameworkCore;
using System;
namespace DataModels.DataProviders.Ef.Contexts;

public class SqLiteDbContext : DataContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseSqlite(@"Data Source = C:\Data\db.db");
    }
}

