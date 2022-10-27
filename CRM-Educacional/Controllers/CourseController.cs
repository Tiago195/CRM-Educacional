using Microsoft.AspNetCore.Mvc;
using CRM_Educacional.Models;
using CRM_Educacional.Repositories;
using CRM_Educacional.Dtos;

namespace CRM_Educacional.Controllers;

public class CourseController : Controller
{
  private readonly ICourseRepository _repository;

  public CourseController(ICourseRepository repository)
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
  public IActionResult Create(CourseModel course)
  {
    if (!ModelState.IsValid) return View(course);

    _repository.Create(course);
    return RedirectToAction("Index");
  }

}