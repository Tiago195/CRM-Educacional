using System.ComponentModel.DataAnnotations;

namespace CRM_Educacional.Models;

public class CourseModel
{
  [Key]
  public int Id { get; set; }
  [Required(ErrorMessage = "Nome do curso é obrigatorio.")]
  [MinLength(2, ErrorMessage = "Insira um nome com pelo no minimo 2 letras")]
  [MaxLength(100, ErrorMessage = "Insira um nome com o maximo de 100 letras")]
  public string Name { get; set; }
  [Required(ErrorMessage = "Tempo do curso é obrigatorio.")]
  [Range(0, 10000, ErrorMessage = "Tempo de curso invalido.")]
  public string Duration { get; set; }
  public ICollection<UserModel> Users { get; set; } = new List<UserModel>();
  // public List<CourseUser> CourseUsers { get; set; }
}