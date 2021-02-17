
using System;

namespace gregs.Models
{
    public class Job
    {
    public Job(string description, float pay, string title)
    {
      Title = title;
      Pay = pay;
      Description = description;
    }
    public string Title{ get; set;}
    public float Pay{ get; set;}
    public string Description{ get; set;}
    public string Id { get; set; } = Guid.NewGuid().ToString();

  }
}