using CRM_Educacional.Models;
using CRM_Educacional.Dtos;

namespace CRM_Educacional.Repositories;

public interface IUserRepository
{
  void Create(UserModel user);
  List<UserModel> GetAll();
  UserInfoDto? GetById(int id);
  void Subscription(int userId, int courseId);
}