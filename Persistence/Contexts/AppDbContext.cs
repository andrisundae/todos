using System;
using Microsoft.EntityFrameworkCore;
using Livecoding.API.Domain.Models;

namespace Livecoding.API.Persistence.Contexts
{
  public class AppDbContext : DbContext
  {
    public DbSet<ToDo> ToDos { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      builder.Entity<ToDo>().ToTable("ToDos");
      builder.Entity<ToDo>().HasKey(p => p.Id);
      builder.Entity<ToDo>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
      builder.Entity<ToDo>().Property(p => p.ExpiryDate).IsRequired();
      builder.Entity<ToDo>().Property(p => p.Title).IsRequired().HasMaxLength(50);
      builder.Entity<ToDo>().Property(p => p.Description).HasMaxLength(50);
      builder.Entity<ToDo>().Property(p => p.Complete).HasDefaultValue(0);

      DateTime expiry1 = new DateTime(2020, 06, 01, 00, 00, 00);
      DateTime expiry2 = new DateTime(2020, 06, 05, 00, 00, 00);

      builder.Entity<ToDo>().HasData
      (
        new ToDo { Id = 100, ExpiryDate = expiry1, Title= "Task 1", Description= "Description Task 1", Complete=20 }, // Id set manually due to in-memory provider
        new ToDo { Id = 101, ExpiryDate = expiry2, Title= "Task 2"} // Description is not required and complete hasdefault value 0
      );
    }
  }
}