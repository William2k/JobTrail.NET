using JobTrail.API.Controllers.Base;
using JobTrail.API.Models;
using JobTrail.Core.Services.Interfaces;
using JobTrail.Data;
using JobTrail.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace JobTrail.API.Controllers
{
    public class JobController : BaseController
    {
        private readonly UserManager<User> _userManager;

        private readonly IJobService _jobService;

        public JobController(UserManager<User> userManager, IJobService jobService)
        {
            _userManager = userManager;
            _jobService = jobService;
        }

        [HttpGet]
        public IActionResult GetJobs(Guid? groupId, DateTime? from, DateTime? to)
        {
            var filteredJobs = _jobService.GetJobs(userId: CurrentUserId, groupId: groupId, from: from, to: to);

            return Ok(filteredJobs);
        }

        [HttpPost]
        public async Task<IActionResult> AddJob(AddJob addJob)
        {
            if(addJob.AssignedUserId == null)
            {
                addJob.AssignedUserId = CurrentUserId;
            }

            var job = addJob.GetJob();
            await _jobService.AddJob(job);

            return CreatedAtAction(nameof(AddJob), job);
        }
    }
}
