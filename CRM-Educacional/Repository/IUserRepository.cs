using CRM_Educacional.Models;
using CRM_Educacional.Dtos;

namespace CRM_Educacional.Repositories;

public interface IUserRepository
{
  void Create(UserModel user);
  void Delete(UserModel user);
  List<UserModel> GetAll();
  UserInfoDto? GetById(int id);
  UserModel? GetByCPF(UserLoginDto user);
  void Update(UserModel user);
  void Subscription(int userId, int courseId);
  public List<UserModel> Search(string userName);
}