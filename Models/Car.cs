
using System;

namespace gregs.Models
{
    public class Car
    {
    public Car( string description, int year, float price, string make, string model)
    {
      Make = make;
      Model = model;
      Price = price;
      Year = year;
      Description = description;
    }
    public string Make{ get; set;}
    public string Model{ get; set;}
    public float Price{ get; set;}
    public int Year{ get; set;}
    public string Description{ get; set;}
    public string Id { get; set; } = Guid.NewGuid().ToString();

  }
}