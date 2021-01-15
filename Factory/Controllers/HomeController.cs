using Factory.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
namespace ProgramName.Controllers
{
  public class HomeController : Controller
  {

    private readonly FactoryContext _db;
    public HomeController(FactoryContext db)
    {
      _db=db;
    }
    [Route ("/")]
    public ActionResult Index()
    {
      ViewBag.Machines = _db.Machines.ToList();
      ViewBag.Engineers = _db.Engineers.ToList();
      return View();
    }
  }
}