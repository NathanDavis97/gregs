using System.Collections.Generic;
using gregs.Models;
using System;
using gregs.Services;
using Microsoft.AspNetCore.Mvc;

namespace gregs.Controllers
{ [ApiController]
    [Route("[controller]")]
    public class HouseController : ControllerBase
    {
          private readonly HouseService _hs;
    public HouseController(HouseService hs)
    {
      _hs = hs;
    }
        [HttpGet]
        public ActionResult<IEnumerable<Car>> Get()
        {
            try
            {
        return Ok(_hs.Get());
      }
            catch (System.Exception err)
            {
                
                return BadRequest(err.Message);
            }
        }
        [HttpGet("{id}")]
    public ActionResult<House> Get(string id)
    {
      try
      {
        House house = _hs.GetById(id);
        return Ok(house);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }

    }
        [HttpPost]
        public ActionResult<House> Create([FromBody] House newHouse)
        {
            try
            {
        House house = _hs.Create(newHouse);
        return Ok(house);
      }
            catch (System.Exception err)
            {
                
                return BadRequest(err.Message);
            }
        }
        [HttpDelete("{houseId}")]
    public ActionResult<string> Delete(string houseId)
    {
      try
      {
        _hs.Delete(houseId);
        {
          return Ok("House Purchased");
        };
        throw new System.Exception("House does not exist");
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }

    }

   [HttpPut("{houseId}")]
        public ActionResult<House> edit([FromBody] House houseUpdate, string houseId)
        {
            try
            {
        houseUpdate.Id = houseId;
        House house = _hs.Edit(houseUpdate);
        return Ok(houseUpdate);
      }
            catch (System.Exception err)
            {
                
                return BadRequest(err.Message);
            }
        }
    }
}