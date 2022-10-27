
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
      var server = Environment.GetEnvironmentVariable("server");
      optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("MYSQLCONNSTR_localdb"));
    }
  }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<UserModel>()
    .HasMany(x => x.Courses)
    .WithMany(x => x.Users);

    modelBuilder.Entity<UserModel>().HasData(
      new UserModel
      {
        Id = 1,
        Name = "Fadiga",
        Phone = "(32) 89745-6544",
        Email = "Fadiga@email.com",
        CPF = "06005932170"
      },
      new UserModel
      {
        Id = 2,
        Name = "Tiago",
        Phone = "(22) 99748-4850",
        Email = "Tiago@email.com",
        CPF = "32145647770",
      }
    );
    modelBuilder.Entity<CourseModel>().HasData(
      new CourseModel
      {
        Id = 1,
        Name = "C#",
        Duration = "1200"
      },
      new CourseModel
      {
        Id = 2,
        Name = "JavaScript",
        Duration = "800"
      },
      new CourseModel
      {
        Id = 3,
        Name = "Python",
        Duration = "1350"
      }
    );
  }

}