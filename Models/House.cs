using System;

namespace gregs.Models
{
    public class House
    {
        public House( string description, int year, float price, int floors, int bedrooms)
    {
      Floors = floors;
      Bedrooms = bedrooms;
      Price = price;
      Year = year;
      Description = description;
    }
    public int Floors{ get; set;}
    public int Bedrooms{ get; set;}
    public float Price{ get; set;}
    public int Year{ get; set;}
    public string Description{ get; set;}
    public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}