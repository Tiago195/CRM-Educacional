
using Microsoft.EntityFrameworkCore;
using CRM_Educacional.Models;

namespace CRM_Educacional.Repositories;

public interface IContext
{
  DbSet<UserModel> Users { get; set; }
  DbSet<CourseModel> Courses { get; set; }
  int SaveChanges();
}