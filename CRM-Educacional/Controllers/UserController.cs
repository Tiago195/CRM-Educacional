using Microsoft.AspNetCore.Mvc;
using CRM_Educacional.Models;
using CRM_Educacional.Repositories;
using CRM_Educacional.Dtos;

namespace CRM_Educacional.Controllers;

public class UserController : Controller
{
  private readonly IUserRepository _repository;

  public UserController(IUserRepository repository)
  {
    _repository = repository;
  }

  public IActionResult Index()
  {
    return View(_repository.GetAll());
  }

  public IActionResult Create()
  {
    return View();
  }

  [HttpPost]
  public IActionResult Create(UserModel user)
  {
    _repository.Create(user);

    return RedirectToAction("Index");
  }

  public IActionResult Login()
  {
    return View();
  }

  [HttpPost]
  public IActionResult Login(UserLoginDto user)
  {
    var userExist = _repository.GetByCPF(user);

    if (userExist == null) return BadRequest();

    return RedirectToAction("Info", new { id = userExist.Id });
  }

  public IActionResult Info(int id)
  {
    var user = _repository.GetById(id);
    return View(user);
  }

  public IActionResult Subscription([FromRoute] int id)
  {
    _repository.Subscription(id, int.Parse(Request.Form["Id"]));
    return RedirectToAction("Info", new { id = id });
  }

  // public IActionResult Subscription(int id)
  // {
  //   // _repository.Subscription(user, course);
  //   System.Console.WriteLine(id);
  //   return View();
  // }

}