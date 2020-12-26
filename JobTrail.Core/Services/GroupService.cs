using JobTrail.Core.Services.Interfaces;
using JobTrail.Data.Entities;
using JobTrail.Data.Interfaces;
using JobTrail.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTrail.Core.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGenericRepository<Group> _groupRepository;
        private readonly IGenericRepository<UserGroupRoles> _userGroupsRepository;
        private readonly RoleManager<Role> _roleManager;

        public GroupService(IGenericRepository<Group> groupRepository, IGenericRepository<UserGroupRoles> userGroupsRepository, RoleManager<Role> roleManager)
        {
            _groupRepository = groupRepository;
            _userGroupsRepository = userGroupsRepository;
            _roleManager = roleManager;
        }

        public IEnumerable<Group> GetUserGroups(Guid userId)
        {
            var groups = _userGroupsRepository
                .Get(x => x.UserId == userId)
                .Include(x => x.Group)
                .Select(x => x.Group);

            return groups;
        }

        public async Task AddGroup(Group group, Guid creatorId)
        {
            await _groupRepository.Insert(group, saveToDb: false);

            var role = await _roleManager.FindByNameAsync(Constants.AdministratorRole);

            var userGroup = new UserGroupRoles
            {
                Group = group,
                UserId = creatorId,
                Role = role
            };

            await _userGroupsRepository.Insert(userGroup);
        }
    }
}
