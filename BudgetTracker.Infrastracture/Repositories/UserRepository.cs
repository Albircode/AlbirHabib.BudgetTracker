using BudgetTracker.Core.Entities;
using BudgetTracker.Core.RepositoryInterfaces;
using BudgetTracker.Infrastracture.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Infrastracture.Repositories
{
    public class UserRepository : EFRepository<User>, IUserRepository
    {
        private readonly UserDbcontext _dbContext;
        public UserRepository(UserDbcontext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<User> GetUserByName(string name)
        {
           var user = await _dbContext.Users.Include(u => u.Incomes).Include(u => u.Expenditures).
                 FirstOrDefaultAsync(u => u.FullName == name);
            if (user == null)
            {
                return null;
            }
            return user;
        }
    }
}
