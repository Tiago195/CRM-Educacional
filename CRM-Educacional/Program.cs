using CRM_Educacional.Repositories;
using CRM_Educacional.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var DbHost = Environment.GetEnvironmentVariable("DB_HOST");
var DbName = Environment.GetEnvironmentVariable("DB_NAME");
var DbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
var connectionString = $"Data Source={DbHost};Initial Catalog={DbName};User ID=sa;Password={DbPassword}";
builder.Services.AddDbContext<IContext, Context>(options => options.UseSqlServer(connectionString, opt => opt.EnableRetryOnFailure()));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Home/Error");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

DatabaseService.MigrationInitialisation(app);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();

public partial class Program { }