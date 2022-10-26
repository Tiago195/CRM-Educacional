using Newtonsoft.Json;
using CRM_Educacional.Models;
using System.Text;
using CRM_Educacional.Repositories;
using CRM_Educacional.Dtos;


namespace CRM_Educacional.Test;

public class UserRepositoryTest
{


  [Fact]
  public async void TestGetAll()
  {
    var repository = new UserRepository(Helpers.GetContext("get"));

    var users = repository.GetAll();

    users.Should().BeAssignableTo<List<UserModel>>();
    users.Count().Should().Be(2);
    users[0].Name.Should().Be("userOne");
    users[1].Name.Should().Be("userTwo");
  }

  [Fact]
  public void TestGetByIdCaseSuccess()
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
  public void TestGetByIdCaseFail()
  {
    // Given
    var repository = new UserRepository(Helpers.GetContext("get"));

    // When
    Action act = () => repository.GetById(99);

    // Then
    act.Should().Throw<ArgumentNullException>();
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
    userThree!.Name.Should().Be("userThree");
    userThree.MyCourses.Count().Should().Be(0);
  }

  [Fact]
  public void TestSubscriptionCaseSuccess()
  {
    // Given
    var repository = new UserRepository(Helpers.GetContext("update"));
    var user = new UserModel() { Name = "userThree", Email = "userThree@gmail.com", CPF = "35175968452", Phone = "(32) 95175-3518" };

    // When
    repository.Create(user);
    repository.Subscription(3, 1);
    var userThree = repository.GetById(3);

    // Then
    userThree.Should().BeAssignableTo<UserInfoDto>();
    userThree!.Name.Should().Be("userThree");
    userThree.Id.Should().Be(3);
    userThree.MyCourses.Count().Should().Be(1);
    userThree.OtherCourses.Count().Should().Be(1);
    userThree.MyCourses[0].Name.Should().Be("Java");
  }

  [Fact]
  public void TestSubscriptionCaseFails()
  {
    // Given
    var repository = new UserRepository(Helpers.GetContext("update"));

    Action act = () => repository.Subscription(99, 99);

    // Then
    act.Should().Throw<ArgumentNullException>();
  }
}