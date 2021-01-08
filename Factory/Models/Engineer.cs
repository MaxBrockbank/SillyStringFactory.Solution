using System.Collections.Generic;

namespace Factory.Models
{
  public class Engineer
  {
    public Engineer()
    {
      this.Machines = new HasSet<EngineerMachine>();
    }
    public int EngineerId {get; set;}
    public string Name {get; set;} 
    public ICollection <EngineerMachine> Machines {get; set;}
  }
}