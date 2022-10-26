using CRM_Educacional.Dtos;
using CRM_Educacional.Models;

namespace CRM_Educacional.Repositories;

public class CourseRepository : ICourseRepository
{
  private readonly IContext _context;

  public CourseRepository(IContext context)
  {
    _context = context;
  }

  public List<CourseModel> GetAll()
  {
    return _context.Courses.ToList();
  }

  public CourseModel? GetById(int id)
  {
    var course = _context.Courses.Find(id);

    return course;
  }

  public void Create(CourseModel course)
  {
    _context.Courses.Add(course);
    _context.SaveChanges();
  }

  public void Update(CourseModel course)
  {
    _context.Courses.Update(course);
    _context.SaveChanges();
  }

  public void Delete(CourseModel course)
  {
    _context.Courses.Remove(course);
    _context.SaveChanges();
  }
}