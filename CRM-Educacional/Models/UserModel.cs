using System.ComponentModel.DataAnnotations;

namespace CRM_Educacional.Models;

public class UserModel
{
  [Key]
  public int Id { get; set; }
  [Required(ErrorMessage = "Nome do candidato é obrigatorio.")]
  [MinLength(2, ErrorMessage = "Insira um nome com pelo no minimo 2 letras")]
  [MaxLength(100, ErrorMessage = "Insira um nome com o maximo de 100 letras")]
  public string Name { get; set; }
  [Required(ErrorMessage = "Documento do candidato é obrigatorio.")]
  [DocumentFormat(ErrorMessage = "Documento do candidato é invalido.")]
  [MinLength(11)]
  [MaxLength(14)]
  public string CPF { get; set; }
  [Required(ErrorMessage = "Email do candidato é obrigatorio.")]
  [MaxLength(100, ErrorMessage = "Insira um Email com o maximo de 100 letras")]
  [EmailAddress]
  public string Email { get; set; }
  [Required(ErrorMessage = "Celular do candidato é obrigatorio.")]
  [Phone(ErrorMessage = "Numero de celular invalido.")]
  [PhoneFormat(ErrorMessage = "Informe um numero com o seguinte formato (xx) xxxxx-xxxx")]
  [StringLength(15)]
  public string Phone { get; set; }
  public ICollection<CourseModel> Courses { get; set; } = new List<CourseModel>();
  // public List<CourseUser> CourseUsers { get; set; }
}

public class PhoneFormat : ValidationAttribute
{
  public override bool IsValid(object? value)
  {
    var phoneNumner = (String)value;

    if (phoneNumner == null || phoneNumner.Trim().Length != 15) return false;
    if (phoneNumner[0] != '(' || phoneNumner[3] != ')') return false;
    if (phoneNumner[4] != ' ' || phoneNumner[10] != '-') return false;

    return true;
  }
}

public class DocumentFormat : ValidationAttribute
{

  public override bool IsValid(object? value)
  {
    var document = (String)value;
    if (document == null) return false;
    return IsCpf(document);
  }
  private static bool IsCpf(string cpf)
  {
    int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
    int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
    string tempCpf;
    string digito;
    int soma;
    int resto;
    cpf = cpf.Trim();
    cpf = cpf.Replace(".", "").Replace("-", "");
    if (cpf.Length != 11)
      return false;
    tempCpf = cpf.Substring(0, 9);
    soma = 0;

    for (int i = 0; i < 9; i++)
      soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
    resto = soma % 11;
    if (resto < 2)
      resto = 0;
    else
      resto = 11 - resto;
    digito = resto.ToString();
    tempCpf = tempCpf + digito;
    soma = 0;
    for (int i = 0; i < 10; i++)
      soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
    resto = soma % 11;
    if (resto < 2)
      resto = 0;
    else
      resto = 11 - resto;
    digito = digito + resto.ToString();
    return cpf.EndsWith(digito);
  }
}