using CRM_Educacional.Dtos;
using CRM_Educacional.Models;

namespace CRM_Educacional.Repositories;

public class UserRepository : IUserRepository
{
  private readonly IContext _context;

  public UserRepository(IContext context)
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

    if (user == null) throw new ArgumentNullException($"user id: {userId} not found");

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
    var userExist = _context.Users.FirstOrDefault(x => x.Email == user.Email);

    if (userExist != null) throw new Exception("User already exist");

    _context.Users.Add(user);
    _context.SaveChanges();
  }

  public void Subscription(int userId, int courseId)
  {
    var user = _context.Users.Find(userId);
    var course = _context.Courses.Find(courseId);

    if (user == null || course == null) throw new ArgumentNullException($"user id: {userId} or course id: {courseId} not found");

    user.Courses.Add(course);

    _context.SaveChanges();
  }
}