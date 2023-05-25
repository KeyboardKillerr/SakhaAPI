using DataModels.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataModels.DataProviders.Ef.Core;

public class DataContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder mb)
    {
        var client = new User()
        {
            Id = Guid.NewGuid(),
            Name = "root",
            Email = "None",
            Password = Entities.User.ToHashString("root"),
        };
        mb.Entity<User>().HasData(client);
    }
}
