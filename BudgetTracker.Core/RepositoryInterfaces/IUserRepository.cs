using BudgetTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Core.RepositoryInterfaces
{
   public interface IUserRepository : IAsyncRepository<User>
    {
        Task<User> GetUserByName(string name);
        Task<User> GetUserById(int id);

        Task<IEnumerable<User>> GetAllUsersasync();
    }
}
