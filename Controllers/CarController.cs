
using System.Collections.Generic;
using gregs.db;
using gregs.Models;
using Microsoft.AspNetCore.Mvc;

namespace gregs.Controllers


{
    [ApiController]
    [Route("[controller]")]

    public class CarController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Car>> Get()
        {
            try
            {
        return Ok(FakeDb.Cars);
      }
            catch (System.Exception err)
            {
                
                return BadRequest(err.Message);
            }
        }
        [HttpPost]
        public ActionResult<Car> Create([FromBody] Car newCar)
        {
            try
            {
        FakeDb.Cars.Add(newCar);
        return Ok(newCar);
      }
            catch (System.Exception err)
            {
                
                return BadRequest(err.Message);
            }
        }
        [HttpDelete("{carId}")]
    public ActionResult<string> Delete(string carId)
    {
      try
      {
        Car carToRemove = FakeDb.Cars.Find(c => c.Id == carId);
        if (FakeDb.Cars.Remove(carToRemove))
        {
          return Ok("Car Purchased");
        };
        throw new System.Exception("Car does not exist");
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }

    }

   [HttpPut("{carId}")]
        public ActionResult<Car> edit([FromBody] Car carUpdate, string carId)
        {
            try
            {
                Car carToEdit = FakeDb.Cars.Find(c => c.Id == carId);
        carUpdate.Make = carUpdate.Make != null ? carUpdate.Make : carToEdit.Make;
        carUpdate.Model = carUpdate.Model != null ? carUpdate.Model : carToEdit.Model;
        carUpdate.Description = carUpdate.Description != null ? carUpdate.Description : carToEdit.Description;
        return Ok(carUpdate);
      }
            catch (System.Exception err)
            {
                
                return BadRequest(err.Message);
            }
        }
    }
}