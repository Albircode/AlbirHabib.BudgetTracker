using BudgetTracker.Core.Entities;
using BudgetTracker.Core.models.Request;
using BudgetTracker.Core.models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Core.ServiceInterfaces
{
    public interface IUserService
    {
        Task<UserResponseModel> GetUserById(int id);
        Task<IEnumerable<UserResponseModel>> GetAllUsers();
        Task<UserResponseModel> AddUser(UserRequestModel model);
        Task<UserResponseModel> UpdateUser(UserRequestModel model);
        Task DeleteUser(UserRequestModel model);

    }
}
