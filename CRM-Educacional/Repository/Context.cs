
using Microsoft.EntityFrameworkCore;
using CRM_Educacional.Models;

namespace CRM_Educacional.Repositories;

public class Context : DbContext, IContext
{

  public DbSet<UserModel> Users { get; set; }
  public DbSet<CourseModel> Courses { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    if (!optionsBuilder.IsConfigured)
    {
      optionsBuilder.UseSqlServer(@"
        Server=127.0.0.1;
        Database=CRM-Educacional;
        User=SA;
        Password=Password12
      ");
    }
  }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<UserModel>()
    .HasMany(x => x.Courses)
    .WithMany(x => x.Users);
  }

}