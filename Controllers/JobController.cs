
using System.Collections.Generic;
using System;
using gregs.Models;
using gregs.Services;
using Microsoft.AspNetCore.Mvc;

namespace gregs.Controllers


{
    [ApiController]
    [Route("[controller]")]

    public class JobController : ControllerBase
    {
    private readonly JobService _js;
    public JobController(JobService js)
    {
      _js = js;
    }

    [HttpGet]
        public ActionResult<IEnumerable<Job>> Get()
        {
            try
            {
        return Ok(_js.Get());
      }
            catch (System.Exception err)
            {
                
                return BadRequest(err.Message);
            }
        }
        [HttpGet("{id}")]
    public ActionResult<Job> Get(string id)
    {
      try
      {
        Job job = _js.GetById(id);
        return Ok(job);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }

    }
        [HttpPost]
        public ActionResult<Job> Create([FromBody] Job newJob)
        {
            try
            {
        Job job = _js.Create(newJob);
        return Ok(job);
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
        _js.Delete(jobId);
        {
          return Ok("Job Deleted");
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
        jobUpdate.Id = jobId;
        Job job = _js.Edit(jobUpdate);
        return Ok(jobUpdate);
      }
            catch (System.Exception err)
            {
                
                return BadRequest(err.Message);
            }
        }
    }
}