using JobTrail.Core.Services.Interfaces;
using JobTrail.Data.Entities;
using JobTrail.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobTrail.Core.Services
{
    public class JobService : IJobService
    {
        private readonly IGenericRepository<Job> _jobRepository;

        public JobService(IGenericRepository<Job> jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task AddJob(Job job)
        {
            await _jobRepository.Insert(job);
        }

        public IEnumerable<Job> GetJobs(Guid? userId = null, Guid? groupId = null, DateTime? from = null, DateTime? to = null)
        {
            var filteredJobs = _jobRepository
                .Get(x => 
                    (!x.DueDate.HasValue || (!from.HasValue || x.DueDate.Value >= from.Value) && (!to.HasValue || x.DueDate.Value >= to.Value)) &&
                    (!userId.HasValue || x.AssignedUser.Id == null || (x.AssignedUser.Id == userId.Value)) &&
                    (!groupId.HasValue || x.Group.Id == groupId.Value)
                );

            return filteredJobs;
        }
    }
}
