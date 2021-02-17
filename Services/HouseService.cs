using System;
using System.Collections.Generic;
using gregs.db;
using gregs.Models;
namespace gregs.Services
{
    public class HouseService
    {
    public IEnumerable<House> Get()
    {
      return FakeDb.Houses;
    }

    public House GetById(string id)
    {
      House house = FakeDb.Houses.Find(h => h.Id == id);
      if (house == null)
      {
        throw new Exception("invalid Id");
      }
      return house;
    }

    public House Create(House newHouse)
    {
      FakeDb.Houses.Add(newHouse);
      return newHouse;
    }

    public House Edit(House updated)
    {
      House house = FakeDb.Houses.Find(h => h.Id == updated.Id);
      if (house == null)
      {
        throw new Exception("invalid Id");
      }
      FakeDb.Houses.Remove(house);
      FakeDb.Houses.Add(updated);
      return updated;
    }

    public string Delete(string id)
    {
      House house = FakeDb.Houses.Find(h => h.Id == id);
      if (house == null)
      {
        throw new Exception("invalid Id");
      }
      FakeDb.Houses.Remove(house);
      return "Deleted";
    }
    }
}