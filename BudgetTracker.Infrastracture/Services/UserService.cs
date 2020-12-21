using BudgetTracker.Core.Entities;
using BudgetTracker.Core.models.Request;
using BudgetTracker.Core.models.Response;
using BudgetTracker.Core.RepositoryInterfaces;
using BudgetTracker.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Infrastracture.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IIncomeRepository _incomeRepository;
        private readonly IExpenditureRepository _expenditureRepository;

        public UserService(IUserRepository userRepository, IIncomeRepository incomeRepository, IExpenditureRepository expenditureRepository)
        {
            _userRepository = userRepository;
           _incomeRepository = incomeRepository;
            _expenditureRepository = expenditureRepository;
        }
        public async Task<UserResponseModel> AddUser(UserRequestModel model)
        {
            var userExist = await _userRepository.GetUserByName(model.FullName);
            if (userExist != null)
            {
                throw new Exception("User already exist");
            }
            var user = new User
            {
                Email = model.Email,
                Password = model.Password,
                FullName = model.FullName
            };
            var createdUser = await _userRepository.AddAsync(user);
            var res = new UserResponseModel
            {
                Id = createdUser.Id,
                FullName = createdUser.FullName,
                Email = createdUser.Email
            };
            return res;
        }

        public async Task DeleteUser(int id)
        {
            var user = await _userRepository.GetUserById(id);
            foreach (var income in user.Incomes)
            {
               await _incomeRepository.DeleteAsync(income);
            }
            foreach (var expenditure in user.Expenditures)
            {
                await _expenditureRepository.DeleteAsync(expenditure);
            }
            await _userRepository.DeleteAsync(user);
        }

       

        public async Task<IEnumerable<UserResponseModel>> GetAllUsersasync()
        {
            var users = await _userRepository.GetAllUsersasync();
            var res = new List<UserResponseModel>();
            foreach (var user in users)
            {
                decimal totalexp = 0;
                decimal totalIncome = 0;

                foreach (var exp in user.Expenditures)
                {
                    totalexp += exp.Amount;
                }
                foreach (var exp in user.Incomes)
                {
                    totalIncome += exp.Amount;
                }
                res.Add(new UserResponseModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    FullName = user.FullName,
                    TotalExpenditures =totalexp,
                    TotalIncomes = totalIncome
                });
              
            }
            return res;
            
        }

        public async Task<UserDetailResponseModel> GetUserById(int id)
        {
            var user = await _userRepository.GetUserById(id);
            var res = new UserDetailResponseModel
            {
                FullName = user.FullName,
                Email = user.Email,
                TotalExpenditures = user.Expenditures.Sum(exp => exp.Amount),
                TotalIncomes = user.Incomes.Sum(i => i.Amount),
            };
            res.Expenditures = new List<Expenditure>();
            foreach (var userExp in user.Expenditures)
            {
                res.Expenditures.Add(new Expenditure
                {
                    Id = userExp.Id,
                    Amount = userExp.Amount,
                    ExpDate = userExp.ExpDate,
                    Description = userExp.Description,
                    Remarks = userExp.Remarks
                });
            }
            res.Incomes = new List<Income>();
            foreach (var userIncome in user.Incomes)
            {
                res.Incomes.Add(new Income
                {
                    Id = userIncome.Id,
                    Amount = userIncome.Amount,
                    IncomeDate = userIncome.IncomeDate,
                    Description = userIncome.Description,
                    Remarks = userIncome.Remarks
                });
            }
            return res;
        }

        public async Task<UserDetailResponseModel> GetUserByName(string name)
        {
            var user = await _userRepository.GetUserByName(name);
            var res = new UserDetailResponseModel
            {
                FullName = user.FullName,
                Email = user.Email,
                TotalExpenditures = user.Expenditures.Sum(exp => exp.Amount),
                TotalIncomes = user.Incomes.Sum(i => i.Amount),
            };
            res.Expenditures = new List<Expenditure>();
            foreach (var userExp in user.Expenditures)
            {
                res.Expenditures.Add(new Expenditure
                {
                    Id = userExp.Id,
                    Amount = userExp.Amount,
                    ExpDate = userExp.ExpDate,
                    Description = userExp.Description,
                    Remarks = userExp.Remarks
                });
            }
            res.Incomes = new List<Income>();
            foreach (var userIncome in user.Incomes)
            {
                res.Incomes.Add(new Income
                {
                    Id = userIncome.Id,
                    Amount = userIncome.Amount,
                    IncomeDate = userIncome.IncomeDate,
                    Description = userIncome.Description,
                    Remarks = userIncome.Remarks
                });
            }
            return res;
        }

        public async Task<UserResponseModel> UpdateUser(UserRequestModel model, int id)
        {
            var userToBeUpdated = await _userRepository.GetByIdAsync(id);
            if (userToBeUpdated == null)
            {
                throw new Exception("User does not exist");
            }
            userToBeUpdated.FullName = model.FullName;
            userToBeUpdated.Email = model.Email;
            userToBeUpdated.Password = model.Password;
           var updatedUser =  await _userRepository.UpdateAsync(userToBeUpdated);
            var res = new UserResponseModel
            {
                Id = updatedUser.Id,
                Email = updatedUser.Email,
                FullName = updatedUser.FullName
            };
            return res;
        }

        
    }
}
