using JobTrail.API.Controllers.Base;
using JobTrail.API.Models;
using JobTrail.Core.Entities;
using JobTrail.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace JobTrail.API.Controllers
{
    public class JobController : BaseController
    {
        private readonly UserManager<User> _userManager;
        private readonly JTContext _context;

        public JobController(UserManager<User> userManager, JTContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetJobs()
        {
            var currentUser = await _userManager.FindByIdAsync(CurrentUserId.ToString());

            await _context.Entry(currentUser).Collection(x => x.Jobs).LoadAsync();

            return Ok(currentUser.Jobs);
        }

        [HttpPost]
        public async Task<IActionResult> AddJob(AddJob addJob)
        {
            if(addJob.AssignedUserId == null)
            {
                addJob.AssignedUserId = CurrentUserId;
            }

            var job = addJob.GetJob();

            job.ParentJob = _context.Jobs.FirstOrDefault(m => m.Id == addJob.ParentJobId);
            job.AssignedUser = await _userManager.FindByIdAsync(addJob.AssignedUserId.ToString());

            _context.Jobs.Add(job);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(AddJob), job);
        }
    }
}
