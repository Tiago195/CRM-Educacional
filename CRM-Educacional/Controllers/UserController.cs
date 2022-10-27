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
    if (!ModelState.IsValid) return View(user);

    try
    {
      _repository.Create(user);
    }
    catch (System.Exception e)
    {
      ViewData["Error"] = e.Message;
      return View(user);
    }

    return View("Index", _repository.GetAll());
  }

  public IActionResult Info(int id)
  {
    try
    {
      return View(_repository.GetById(id));
    }
    catch (System.Exception)
    {
      return View("NotFound");
    }
  }

  public IActionResult Subscription([FromRoute] int id)
  {
    try
    {
      _repository.Subscription(id, int.Parse(Request.Form["Id"]));

      return RedirectToAction("Info", new { Id = id });
    }
    catch (System.Exception)
    {
      return View("NotFound");
    }
  }

}