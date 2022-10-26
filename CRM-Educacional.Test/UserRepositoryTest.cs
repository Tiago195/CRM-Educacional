using Newtonsoft.Json;
using CRM_Educacional.Models;
using System.Text;
using CRM_Educacional.Repositories;
using CRM_Educacional.Dtos;


namespace CRM_Educacional.Test;

public class IntegrationTestUser
{


  [Fact]
  public async void TestGetAll()
  {
    // Arrange
    var repository = new UserRepository(Helpers.GetContext("get"));

    var users = repository.GetAll();

    users.Should().BeAssignableTo<List<UserModel>>();
    users.Count().Should().Be(2);
    users[0].Name.Should().Be("userOne");
    users[1].Name.Should().Be("userTwo");
  }

  [Fact]
  public void TestGetById()
  {
    // Given
    var repository = new UserRepository(Helpers.GetContext("get"));
    // When
    var userOne = repository.GetById(1);
    // Then
    userOne.Should().BeAssignableTo<UserInfoDto>();
    userOne!.Name.Should().Be("userOne");
    userOne.Id.Should().Be(1);
    userOne.MyCourses.Count().Should().Be(1);
    userOne.OtherCourses.Count().Should().Be(1);
    userOne.MyCourses[0].Name.Should().Be("Java");
  }

  [Fact]
  public void TestCreate()
  {
    // Given
    var repository = new UserRepository(Helpers.GetContext("create"));
    var user = new UserModel() { Name = "userThree", Email = "userThree@gmail.com", CPF = "35175968452", Phone = "(32) 95175-3518" };

    // When
    repository.Create(user);
    var userThree = repository.GetById(3);
    // Then
    userThree.Name.Should().Be("userThree");
  }
}