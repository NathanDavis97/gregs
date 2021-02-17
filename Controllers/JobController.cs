
using System.Collections.Generic;
using gregs.db;
using gregs.Models;
using Microsoft.AspNetCore.Mvc;

namespace gregs.Controllers


{
    [ApiController]
    [Route("[controller]")]

    public class JobController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Job>> Get()
        {
            try
            {
        return Ok(FakeDb.Jobs);
      }
            catch (System.Exception err)
            {
                
                return BadRequest(err.Message);
            }
        }
        [HttpPost]
        public ActionResult<Job> Create([FromBody] Job newJob)
        {
            try
            {
        FakeDb.Jobs.Add(newJob);
        return Ok(newJob);
      }
            catch (System.Exception err)
            {
                
                return BadRequest(err.Message);
            }
        }
        [HttpDelete("{jobId}")]
    public ActionResult<string> Delete(string jobId)
    {
      try
      {
        Job jobToRemove = FakeDb.Jobs.Find(j => j.Id == jobId);
        if (FakeDb.Jobs.Remove(jobToRemove))
        {
          return Ok("Job Purchased");
        };
        throw new System.Exception("Job does not exist");
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }

    }

   [HttpPut("{jobId}")]
        public ActionResult<Job> edit([FromBody] Job jobUpdate, string jobId)
        {
             try
            {
                Job jobToEdit = FakeDb.Jobs.Find(c => c.Id == jobId);
        jobUpdate.Title = jobUpdate.Title != null ? jobUpdate.Title : jobToEdit.Title;
        jobUpdate.Description = jobUpdate.Description != null ? jobUpdate.Description : jobToEdit.Description;
        return Ok(jobUpdate);
      }
            catch (System.Exception err)
            {
                
                return BadRequest(err.Message);
            }
        }
    }
}