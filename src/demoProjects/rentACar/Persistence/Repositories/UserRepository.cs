using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Domain.Entities;
using Persistence.Contexts;
using Persistence.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UserRepository : EfRepositoryBase<UserApplication, BaseDbContext>, IUserRepository
    {
        public UserRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
