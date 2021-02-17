
using System.Collections.Generic;
using System;
using gregs.Models;
using gregs.Services;
using Microsoft.AspNetCore.Mvc;

namespace gregs.Controllers


{
    [ApiController]
    [Route("[controller]")]

    public class CarController : ControllerBase
    {
    private readonly CarService _cs;
    public CarController(CarService cs)
    {
      _cs = cs;
    }

    [HttpGet]
        public ActionResult<IEnumerable<Car>> Get()
        {
            try
            {
        return Ok(_cs.Get());
      }
            catch (System.Exception err)
            {
                
                return BadRequest(err.Message);
            }
        }
        [HttpGet("{id}")]
    public ActionResult<Car> Get(string id)
    {
      try
      {
        Car car = _cs.GetById(id);
        return Ok(car);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }

    }
        [HttpPost]
        public ActionResult<Car> Create([FromBody] Car newCar)
        {
            try
            {
        Car car = _cs.Create(newCar);
        return Ok(car);
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
        _cs.Delete(carId);
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
        carUpdate.Id = carId;
        Car car = _cs.Edit(carUpdate);
        return Ok(carUpdate);
      }
            catch (System.Exception err)
            {
                
                return BadRequest(err.Message);
            }
        }
    }
}