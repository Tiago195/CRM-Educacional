using Newtonsoft.Json;
using CRM_Educacional.Models;
using System.Text;
using CRM_Educacional.Repositories;
using CRM_Educacional.Controllers;
using CRM_Educacional.Dtos;
using Microsoft.AspNetCore.Mvc;
using Moq;
namespace CRM_Educacional.Test;

public class UserControllerTest
{
  [Fact]
  public void Index()
  {
    var mockRepository = new Mock<IUserRepository>();
    mockRepository.Setup(x => x.GetAll()).Returns(Helpers.GetUsers());
    var controller = new UserController(mockRepository.Object);

    var viewResult = controller.Index() as ViewResult;

    viewResult.Model.Should().BeAssignableTo<List<UserModel>>();
  }

  [Fact]
  public void TestInfoCaseSuccess()
  {
    // Given
    var mockRepository = new Mock<IUserRepository>();
    mockRepository.Setup(x => x.GetById(1)).Returns(Helpers.GetUser());
    var controller = new UserController(mockRepository.Object);

    // When
    var viewResult = controller.Info(1) as ViewResult;

    // Then
    viewResult.Model.Should().BeAssignableTo<UserInfoDto>();
  }

  [Fact]
  public void TestInfoCaseFail()
  {
    // Given
    var mockRepository = new Mock<IUserRepository>();
    mockRepository.Setup(x => x.GetById(999)).Throws(new ArgumentNullException());
    var controller = new UserController(mockRepository.Object);

    // When
    var viewResult = controller.Info(999) as ViewResult;

    // Then
    viewResult.ViewName.Should().Be("NotFound");
  }

  [Fact]
  public void TestCreate()
  {
    // Given
    var mockRepository = new Mock<IUserRepository>();
    var user = new UserModel() { Name = "userThree", Email = "userThree@gmail.com", CPF = "35175968452", Phone = "(32) 95175-3518" };
    mockRepository.Setup(x => x.Create(user));
    var controller = new UserController(mockRepository.Object);

    // When
    var viewResult = controller.Create(user) as ViewResult;

    // Then
    viewResult.ViewName.Should().Be("Index");
  }

  // [Fact]
  // public void TestSubscriptionCaseSuccess()
  // {
  //   // Given
  //   var mockRepository = new Mock<IUserRepository>();
  //   mockRepository.Setup(x => x.Subscription(1, 1));
  //   var controller = new UserController(mockRepository.Object);

  //   // When
  //   var viewResult = controller.Subscription(1) as ViewResult;

  //   // Then
  //   viewResult.ViewName.Should().Be("Info");
  // }

  [Fact]
  public void TestSubscriptionCaseFails()
  {
    // Given
    var mockRepository = new Mock<IUserRepository>();
    mockRepository.Setup(x => x.Subscription(999, 999)).Throws(new ArgumentNullException());
    var controller = new UserController(mockRepository.Object);

    // When
    var viewResult = controller.Subscription(999) as ViewResult;

    // Then
    viewResult.ViewName.Should().Be("NotFound");
  }
}