using JobTrail.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobTrail.Core.Services.Interfaces
{
    public interface IGroupService
    {
        Task AddGroup(Group group, Guid creatorId);
        Task<bool> AddUserToGroup(Guid groupId, Guid userId, string roleName, Guid currentUserId);
        IEnumerable<Group> GetUserGroups(Guid userId);
    }
}