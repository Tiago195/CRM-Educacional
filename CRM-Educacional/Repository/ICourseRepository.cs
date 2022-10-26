using CRM_Educacional.Models;

namespace CRM_Educacional.Repositories;

public interface ICourseRepository
{
  void Create(CourseModel course);
  List<CourseModel> GetAll();
  CourseModel? GetById(int id);
}