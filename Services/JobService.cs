using System;
using System.Collections.Generic;
using gregs.db;
using gregs.Models;
using Microsoft.AspNetCore.Mvc;
namespace gregs.Services
{
    public class JobService
    {
    public IEnumerable<Job> Get()
    {
      return FakeDb.Jobs;
    }

    public Job GetById(string id)
    {
      Job job = FakeDb.Jobs.Find(j => j.Id == id);
      if (job == null)
      {
        throw new Exception("invalid Id");
      }
      return job;
    }

    public Job Create(Job newJob)
    {
      FakeDb.Jobs.Add(newJob);
      return newJob;
    }

    public Job Edit(Job updated)
    {
      Job job = FakeDb.Jobs.Find(j => j.Id == updated.Id);
      if (job == null)
      {
        throw new Exception("invalid Id");
      }
      FakeDb.Jobs.Remove(job);
      FakeDb.Jobs.Add(updated);
      return updated;
    }

    public string Delete(string id)
    {
      Job job = FakeDb.Jobs.Find(j => j.Id == id);
      if (job == null)
      {
        throw new Exception("invalid Id");
      }
      FakeDb.Jobs.Remove(job);
      return "Deleted";
    }
    }
}