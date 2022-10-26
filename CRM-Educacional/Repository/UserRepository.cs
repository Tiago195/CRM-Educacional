using CRM_Educacional.Dtos;
using CRM_Educacional.Models;

namespace CRM_Educacional.Repositories;

public class UserRepository : IUserRepository
{
  private readonly Context _context;

  public UserRepository(Context context)
  {
    _context = context;
  }

  public List<UserModel> GetAll()
  {
    return _context.Users.ToList();
  }

  public UserInfoDto? GetById(int userId)
  {
    var user = _context.Users.Find(userId);
    var courses = _context.Courses.Where(x => x.Users.Any(e => e.Id == userId)).ToList();
    var otherCourses = _context.Courses.Where(x => x.Users.All(e => e.Id != userId)).ToList();

    var userInfo = new UserInfoDto
    {
      Id = user.Id,
      CPF = user.CPF,
      Email = user.Email,
      Name = user.Name,
      Phone = user.Phone,
      MyCourses = courses,
      OtherCourses = otherCourses
    };

    return userInfo;
  }

  public void Create(UserModel user)
  {
    _context.Users.Add(user);
    _context.SaveChanges();
  }

  public void Update(UserModel user)
  {
    _context.Users.Update(user);
    _context.SaveChanges();
  }

  public void Delete(UserModel user)
  {
    _context.Users.Remove(user);
    _context.SaveChanges();
  }

  public UserModel? GetByCPF(UserLoginDto user)
  {
    var userExist = _context.Users.FirstOrDefault(user => user.CPF == user.CPF);

    return userExist;
  }

  public void Subscription(int userId, int courseId)
  {
    var user = _context.Users.Find(userId);
    var course = _context.Courses.Find(courseId);
    // System.Console.WriteLine(userId);
    // System.Console.WriteLine(course.Id);
    if (user.Courses == null)
    {
      user.Courses = new List<CourseModel>();
    }
    // System.Console.WriteLine(course.Id);
    user.Courses.Add(course);

    // _context.Users.Update(user);
    // _context.Entry(user).CurrentValues.SetValues(user);
    _context.SaveChanges();
  }
}