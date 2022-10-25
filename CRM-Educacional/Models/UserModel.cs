using System.ComponentModel.DataAnnotations;

namespace CRM_Educacional.Models;

public class UserModel
{
  [Key]
  public int Id { get; set; }
  public string Name { get; set; }
  public string CPF { get; set; }
  public string Email { get; set; }
  public string Phone { get; set; }
  public ICollection<CourseModel> Courses { get; set; }
  // public List<CourseUser> CourseUsers { get; set; }
}