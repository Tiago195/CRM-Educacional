using CRM_Educacional.Models;

namespace CRM_Educacional.Dtos;

public class UserLoginDto
{
  public string CPF { get; set; }
  public string Password { get; set; }
}

public class UserInfoDto
{
  public int Id { get; set; }
  public string Name { get; set; }
  public string CPF { get; set; }
  public string Email { get; set; }
  public string Phone { get; set; }
  public List<CourseModel> MyCourses { get; set; }
  public List<CourseModel> OtherCourses { get; set; }

  // public List<CourseUser> CourseUsers { get; set; }

}