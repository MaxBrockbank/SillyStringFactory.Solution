using System.Collections.Generic;

namespace Factory.Models
{
  public class Machine
  {
    public Machine()
    {
      this.Engineers = new HasSet<EngineerMachine>();
    }
    public int MachineId {get;set;}
    public string Name {get; set;}
    public virtual ICollection<EngineerMachine> Engineers {get; set;}
  }
}