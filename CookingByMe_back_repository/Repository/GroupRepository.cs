﻿using CookingByMe_back.Core.IRepository;
using CookingByMe_back.Models.GroupModels;

namespace CookingByMe_back.Core.Repository
{
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        public GroupRepository(CookingByMeContext context) : base(context)
        {
        }
    }
}
