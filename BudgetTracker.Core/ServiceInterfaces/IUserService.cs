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
        Task<UserDetailResponseModel> GetUserById(int id);
        Task<UserDetailResponseModel> GetUserByName(string name);
        Task<IEnumerable<UserResponseModel>> GetAllUsersasync();
        Task<UserResponseModel> AddUser(UserRequestModel model);
        Task<UserResponseModel> UpdateUser(UserRequestModel model, int id);
        Task DeleteUser(int id);

    }
}
