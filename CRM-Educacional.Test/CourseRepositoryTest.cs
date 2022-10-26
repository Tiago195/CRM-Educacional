using Newtonsoft.Json;
using CRM_Educacional.Models;
using System.Text;
using CRM_Educacional.Repositories;
using CRM_Educacional.Dtos;


namespace CRM_Educacional.Test;

public class CourseRepositoryTest
{
  [Fact]
  public void TestGetAll()
  {
    // Given
    var repository = new CourseRepository(Helpers.GetContext("get"));

    // When
    var courses = repository.GetAll();

    // Then
    courses.Should().BeAssignableTo<List<CourseModel>>();
    courses.Count().Should().Be(2);
    courses[0].Name.Should().Be("Java");
    courses[1].Name.Should().Be("C#");
  }

  [Fact]
  public void TestGetByIdCaseSuccess()
  {
    // Given
    var repository = new CourseRepository(Helpers.GetContext("get"));

    // When
    var course = repository.GetById(1);

    // Then
    course.Should().BeAssignableTo<CourseModel>();
    course!.Name.Should().Be("Java");
    course.Duration.Should().Be("1000");
  }

  [Fact]
  public void TestGetByIdCaseFail()
  {
    // Given
    var repository = new CourseRepository(Helpers.GetContext("get"));

    // When
    Action act = () => repository.GetById(999);

    // Then
    act.Should().Throw<ArgumentNullException>();
  }

  [Fact]
  public void TestCreate()
  {
    // Given
    var repository = new CourseRepository(Helpers.GetContext("create"));
    var course = new CourseModel() { Name = "JavaScript", Duration = "800" };

    // When
    repository.Create(course);
    var courseJavaScript = repository.GetById(3);

    // Then
    courseJavaScript.Name.Should().Be("JavaScript");
    courseJavaScript.Duration.Should().Be("800");
  }
}