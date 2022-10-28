using CRM_Educacional.Models;
using CRM_Educacional.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CRM_Educacional.Services;

public static class DatabaseService
{
  public static void MigrationInitialisation(this IApplicationBuilder app)
  {
    var scope = app.ApplicationServices.CreateScope();
    var serviceBd = scope.ServiceProvider.GetService<Context>();
    serviceBd.Database.Migrate();
  }
}