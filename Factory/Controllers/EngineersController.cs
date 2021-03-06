using Factory.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Factory.Controllers
{
  public class EngineersController : Controller
  {
    private readonly FactoryContext _db;
    public EngineersController(FactoryContext db)
    {
      _db=db;
    }

    public ActionResult Index()
    {
      return View(_db.Engineers.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
      ViewBag.Machines = _db.Machines.ToList();
      return View();
    }

    [HttpPost]
    public ActionResult Create(Engineer engineer, int MachineId)
    {
      _db.Engineers.Add(engineer);
      if(MachineId != 0)
      {
        _db.EngineerMachine.Add(new EngineerMachine(){EngineerId = engineer.EngineerId, MachineId = MachineId});
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisEngineer = _db.Engineers
        .Include(engineer=>engineer.Machines)
        .ThenInclude(join=>join.Machine)
        .FirstOrDefault(engineer=>engineer.EngineerId ==id);
      return View(thisEngineer);

    }

    public ActionResult Edit(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(engineer=>engineer.EngineerId == id);
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
      ViewBag.Machines = _db.Machines.ToList();
      return View(thisEngineer);
    }

    [HttpPost]
    public ActionResult Edit(Engineer engineer, int MachineId)
    {
      if(MachineId != 0)
      {
        var relationship = _db.EngineerMachine
          .Any(record => record.EngineerId == engineer.EngineerId && record.MachineId == MachineId);
        if(!relationship)
        {
          _db.EngineerMachine.Add(new EngineerMachine() {EngineerId = engineer.EngineerId, MachineId = MachineId});
        }
      }
      _db.Entry(engineer).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", "Engineers", new {id=engineer.EngineerId});
    }

    [HttpPost]
    public ActionResult DeleteMachine(int joinId, int EngineerId)
    {
      var thisEntry = _db.EngineerMachine.FirstOrDefault(entry => entry.EngineerMachineId == joinId);
      _db.EngineerMachine.Remove(thisEntry);
      _db.SaveChanges();
      return RedirectToAction("Details", "Engineers", new{id=EngineerId});
    }

    public ActionResult Delete(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId==id);
      return View(thisEngineer);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId==id);
      _db.Engineers.Remove(thisEngineer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddMachine(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(engineer=>engineer.EngineerId == id);
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
      return View(thisEngineer);
    }

    [HttpPost]
    public ActionResult AddMachine(Engineer engineer, int MachineId)
    {
      if(MachineId != 0)
      {
        var relationship = _db.EngineerMachine
          .Any(record=> record.EngineerId == engineer.EngineerId && record.MachineId == MachineId);
        if(!relationship)
        {
          _db.EngineerMachine.Add( new EngineerMachine(){EngineerId=engineer.EngineerId, MachineId = MachineId});
        }
      }
      _db.SaveChanges();
      return RedirectToAction("Details", "Engineers", new{id=engineer.EngineerId});
    }
  }
}
