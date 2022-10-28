
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using CRM_Educacional.Models;

namespace CRM_Educacional.Repositories;

public class Context : DbContext, IContext
{

  public Context(DbContextOptions<Context> options) : base(options)
  {
    try
    {
      var data = Database.GetService<IContext>() as RelationalDatabaseCreator;
      if (data != null)
      {
        if (!data.CanConnect()) data.Create();
        if (!data.HasTables()) data.CreateTables();
      }
    }
    catch (System.Exception e)
    {

      System.Console.WriteLine(e.Message);
    }
  }

  public DbSet<UserModel> Users { get; set; }
  public DbSet<CourseModel> Courses { get; set; }

  // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  // {
  //   var connectionString = $"Server=127.0.0.1, 1433;Initial Catalog=CRM-Educacional;User ID=SA;Password=Password12";
  //   if (!optionsBuilder.IsConfigured)
  //   {
  //     optionsBuilder.UseSqlServer(connectionString);
  //   }
  // }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<UserModel>()
    .HasMany(x => x.Courses)
    .WithMany(x => x.Users);
    // modelBuilder.Entity<UserModel>().HasData(
    //   new UserModel
    //   {
    //     Id = 1,
    //     Name = "Fadiga",
    //     Phone = "(32) 89745-6544",
    //     Email = "Fadiga@email.com",
    //     CPF = "060.059.321-70"
    //   },
    //   new UserModel
    //   {
    //     Id = 2,
    //     Name = "Tiago",
    //     Phone = "(22) 99748-4850",
    //     Email = "Tiago@email.com",
    //     CPF = "321.456.477-70",
    //   }
    // );
    // modelBuilder.Entity<CourseModel>().HasData(
    //   new CourseModel
    //   {
    //     Id = 1,
    //     Name = "C#",
    //     Duration = "1200"
    //   },
    //   new CourseModel
    //   {
    //     Id = 2,
    //     Name = "JavaScript",
    //     Duration = "800"
    //   },
    //   new CourseModel
    //   {
    //     Id = 3,
    //     Name = "Python",
    //     Duration = "1350"
    //   }
    // );
  }

}