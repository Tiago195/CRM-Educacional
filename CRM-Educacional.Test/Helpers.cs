using CRM_Educacional.Models;
using Microsoft.EntityFrameworkCore;
using CRM_Educacional.Dtos;

namespace CRM_Educacional.Test;

public static class Helpers
{
  public static List<UserModel> GetUsers()
  {
    return new List<UserModel>() {
      new UserModel {
        Name = "userOne",
        Email = "userOne@email.com",
        CPF = "94872978048",
        Phone = "(79) 96913-9992",
        Courses = new List<CourseModel>() {
          new CourseModel {
            Name = "Java",
            Duration = "1000"
          },
        }
      },
      new UserModel {
        Name = "userTwo",
        Email = "userTwo@hotmail.com",
        CPF = "01376925010",
        Phone = "(61) 98483-9678",
        Courses = new List<CourseModel>() {
          new CourseModel {
            Name = "C#",
            Duration = "800"
          }
        }
      }
    };
  }

  public static UserInfoDto GetUser()
  {
    return new UserInfoDto()
    {
      Id = 1,
      Name = "userOne",
      Email = "userOne@email.com",
      CPF = "94872978048",
      Phone = "(79) 96913-9992",
      MyCourses = new List<CourseModel>() {
          new CourseModel {
            Name = "Java",
            Duration = "1000"
          },
        },
      OtherCourses = new List<CourseModel>() {
          new CourseModel {
            Name = "C#",
            Duration = "800"
          }
        }
    };
  }
  public static List<CourseModel> GetCourses()
  {
    return new List<CourseModel>()
    {
      new CourseModel {
        Name = "Java",
        Duration = "1000"
      },
      new CourseModel {
        Name = "C#",
        Duration = "800"
      }
    };
  }

  public static ContextTest GetContext(string DbInMemory)
  {
    var dbContextOptions = new DbContextOptionsBuilder<ContextTest>().UseInMemoryDatabase(DbInMemory).Options;

    var context = new ContextTest(dbContextOptions);

    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();

    context.Users.AddRange(GetUsers());
    // context.Courses.AddRange(GetCourses());

    context.SaveChanges();

    return context;
  }
}