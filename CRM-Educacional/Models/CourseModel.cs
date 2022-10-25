using System.ComponentModel.DataAnnotations;

namespace CRM_Educacional.Models;

public class CourseModel
{
  [Key]
  public int Id { get; set; }
  public string Name { get; set; }
  public string Duration { get; set; }
  public ICollection<UserModel> Users { get; set; }
  // public List<CourseUser> CourseUsers { get; set; }
}