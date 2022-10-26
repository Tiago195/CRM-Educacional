using Newtonsoft.Json;
using CRM_Educacional.Models;
using System.Text;
using CRM_Educacional.Repositories;
using CRM_Educacional.Controllers;
using CRM_Educacional.Dtos;
using Microsoft.AspNetCore.Mvc;
using Moq;
namespace CRM_Educacional.Test;

public class CourseControllerTest
{
  [Fact]
  public async void Index()
  {
    var mockRepository = new Mock<ICourseRepository>();
    mockRepository.Setup(x => x.GetAll()).Returns(Helpers.GetCourses());
    var controller = new CourseController(mockRepository.Object);

    var viewResult = controller.Index() as ViewResult;

    viewResult.Model.Should().BeAssignableTo<List<CourseModel>>();
  }

  [Fact]
  public void TestCreate()
  {
    // Given
    var mockRepository = new Mock<ICourseRepository>();
    var course = new CourseModel() { Name = "JavaScript", Duration = "800" };
    mockRepository.Setup(x => x.Create(course));
    var controller = new CourseController(mockRepository.Object);

    // When
    var viewResult = controller.Create(course) as ViewResult;

    // Then
    viewResult.ViewName.Should().Be("Index");
  }

}