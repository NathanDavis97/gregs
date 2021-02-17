using System.Collections.Generic;
using gregs.Models;

namespace gregs.db
{
  public class FakeDb
  {
    public static List<Car> Cars { get; set; } = new List<Car>();
    public static List<Job> Jobs { get; set; } = new List<Job>();
    public static List<House> Houses { get; set; } = new List<House>();
  }
}