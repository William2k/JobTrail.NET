using JobTrail.API.Controllers.Base;
using JobTrail.API.Models;
using JobTrail.Core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobTrail.API.Controllers
{
    public class GroupController : BaseController
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet]
        public IActionResult GetGroups()
        {
            var groups = _groupService.GetUserGroups(CurrentUserId);

            return Ok(groups);
        }

        [HttpPost]
        public async Task<IActionResult> AddGroup(AddGroup addGroup)
        {
            var group = addGroup.GetGroup();
            await _groupService.AddGroup(group, CurrentUserId);

            return CreatedAtAction(nameof(AddGroup), group);
        }

        [HttpPost("{groupId}/User")]
        public async Task<IActionResult> AddUserToGroup(Guid groupId, Guid userId, string roleName)
        {
            var result = await _groupService.AddUserToGroup(groupId, userId, roleName, CurrentUserId);

            if(!result)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(AddUserToGroup), result);
        }
    }
}
