

using CRM_Educacional.Models;
using CRM_Educacional.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CRM_Educacional.Test;

public class ContextTest : DbContext, IContext
{
  public ContextTest(DbContextOptions<ContextTest> options) : base(options) { }
  public DbSet<UserModel> Users { get; set; }
  public DbSet<CourseModel> Courses { get; set; }
}