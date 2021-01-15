using Factory.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Factory.Controllers
{
  public class MachinesController : Controller
  {
    private readonly FactoryContext _db;
    public MachinesController(FactoryContext db)
    {
      _db=db;
    }

    public ActionResult Index()
    {
      return View(_db.Machines.ToList());
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Machine machine)
    {
      _db.Machines.Add(machine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisMachine = _db.Machines
        .Include(machine=>machine.Engineers)
        .ThenInclude(join=>join.Engineer)
        .FirstOrDefault(machine=> machine.MachineId == id);
      return View(thisMachine);
    }

    public ActionResult Edit(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(machine=>machine.MachineId==id);
      return View(thisMachine);
    }

    [HttpPost]
    public ActionResult Edit(Machine machine, int EngineerId)
    {
      if(EngineerId!=0)
      {
        var relationship = _db.EngineerMachine
          .Any(record=> record.EngineerId == EngineerId && record.MachineId == machine.MachineId);
        if(!relationship)
        {
          _db.EngineerMachine.Add( new EngineerMachine(){EngineerId = EngineerId, MachineId = machine.MachineId});
        }
      }
      _db.Entry(machine).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", "Machines", new {id=machine.MachineId});
    }

    public ActionResult Delete(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(machine=>machine.MachineId==id);
      return View(thisMachine);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirm(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(machine=>machine.MachineId==id);
      _db.Machines.Remove(thisMachine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddEngineer(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(machine=>machine.MachineId == id);
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
      return View(thisMachine);
    }
    
    [HttpPost]
    public ActionResult AddEngineer(Machine machine, int EngineerId)
    {
      if(EngineerId != 0)
      {
        var relationship = _db.EngineerMachine
          .Any(record=> record.MachineId == machine.MachineId && record.EngineerId == EngineerId);
        if(!relationship)
        {
          _db.EngineerMachine.Add( new EngineerMachine(){MachineId = machine.MachineId, EngineerId = EngineerId});
        }
      }
      _db.SaveChanges();
      return RedirectToAction("Details", "Machines", new{id=machine.MachineId});
    }

    [HttpPost]
    public ActionResult DeleteEngineer(int joinId, int MachineId)
    {
      var thisEntry = _db.EngineerMachine.FirstOrDefault(entry=>entry.EngineerMachineId == joinId);
      _db.EngineerMachine.Remove(thisEntry);
      _db.SaveChanges();
      return RedirectToAction("Details", "Machines", new{id=MachineId});
    }
  }
}