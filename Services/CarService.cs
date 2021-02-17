using System;
using System.Collections.Generic;
using gregs.db;
using gregs.Models;
using Microsoft.AspNetCore.Mvc;
namespace gregs.Services
{
    public class CarService
    {
    public IEnumerable<Car> Get()
    {
      return FakeDb.Cars;
    }

    public Car GetById(string id)
    {
      Car car = FakeDb.Cars.Find(c => c.Id == id);
      if (car == null)
      {
        throw new Exception("invalid Id");
      }
      return car;
    }

    public Car Create(Car newCar)
    {
      FakeDb.Cars.Add(newCar);
      return newCar;
    }

    public Car Edit(Car updated)
    {
      Car car = FakeDb.Cars.Find(c => c.Id == updated.Id);
      if (car == null)
      {
        throw new Exception("invalid Id");
      }
      FakeDb.Cars.Remove(car);
      FakeDb.Cars.Add(updated);
      return updated;
    }

    public string Delete(string id)
    {
      Car car = FakeDb.Cars.Find(c => c.Id == id);
      if (car == null)
      {
        throw new Exception("invalid Id");
      }
      FakeDb.Cars.Remove(car);
      return "Deleted";
    }
    }
}