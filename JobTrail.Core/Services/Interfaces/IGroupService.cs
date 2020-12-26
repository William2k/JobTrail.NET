using JobTrail.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobTrail.Core.Services.Interfaces
{
    public interface IGroupService
    {
        Task AddGroup(Group group, Guid creatorId);
        IEnumerable<Group> GetUserGroups(Guid userId);
    }
}