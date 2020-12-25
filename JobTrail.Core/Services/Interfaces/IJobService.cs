using JobTrail.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobTrail.Core.Services.Interfaces
{
    public interface IJobService
    {
        Task AddJob(Job job);
        IEnumerable<Job> GetJobs(Guid? userId = null, Guid? groupId = null, DateTime? from = null, DateTime? to = null);
    }
}