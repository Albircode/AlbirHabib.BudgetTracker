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
           return await _dbContext.Users.Include(u => u.Incomes).Include(u => u.Expenditures).
                 FirstOrDefaultAsync(u => u.FullName == name);
           
        }
        public async Task<IEnumerable<User>> GetAllUsersasync()

        {

            var users = await _dbContext.Users.Include(u => u.Incomes).Include(u => u.Expenditures).ToListAsync();

            return users;

        }

        public async Task<User> GetUserById(int id)
        {
            return await _dbContext.Users.Include(u => u.Incomes).Include(u => u.Expenditures).
                 FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
