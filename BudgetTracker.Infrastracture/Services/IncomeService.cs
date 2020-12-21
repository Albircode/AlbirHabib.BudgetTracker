using BudgetTracker.Core.Entities;
using BudgetTracker.Core.models.Request;
using BudgetTracker.Core.models.Response;
using BudgetTracker.Core.RepositoryInterfaces;
using BudgetTracker.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Infrastracture.Services
{
    public class IncomeService : IIncomeService
    {
        private readonly IIncomeRepository _incomeRepository;

        public IncomeService(IIncomeRepository incomeRepository)
        {
            _incomeRepository = incomeRepository;
        }
        public async Task<IncomeResponseModel> AddIncome(IncomeRequestModel model)
        {
            var income = new Income
            {
                Amount = model.Amount,
                UserId = model.UserId,
                Description = model.Description,
                Remarks = model.Remarks,
                IncomeDate = model.IncomeDate
            };
            await _incomeRepository.AddAsync(income);
            var CreatedIncome = new IncomeResponseModel
            {
                Amount = income.Amount,
                Description = income.Description,
                Remarks = income.Remarks,
                Id = income.Id,
                IncomeDate = income.IncomeDate
            };
            return CreatedIncome;
        }

        public async Task<IEnumerable<IncomeResponseModel>> GetIncomeByUserId(int id)
        {
            var incomes = await _incomeRepository.GetIncomeByUser(id);
            var response = new List<IncomeResponseModel>();
            foreach (var income in incomes)
            {
                response.Add(new IncomeResponseModel
                {
                    Amount = income.Amount,
                    Description = income.Description,
                    Remarks = income.Remarks,
                    Id = income.Id,
                    IncomeDate = income.IncomeDate
                });
            };
            return response;
        }

        public async Task RemoveExpediture(int id)
        {
            var income = await _incomeRepository.GetByIdAsync(id);
            await _incomeRepository.DeleteAsync(income);
        }

        public async Task<IncomeResponseModel> UpdateIncome(IncomeRequestModel model, int id)
        {
            var incometobeUpdated = await _incomeRepository.GetByIdAsync(id);

            incometobeUpdated.Amount = model.Amount;
            incometobeUpdated.Description = model.Description;
            incometobeUpdated.IncomeDate = model.IncomeDate;
            incometobeUpdated.Remarks = model.Remarks;

            var updatedIncome = await _incomeRepository.UpdateAsync(incometobeUpdated);
            if (updatedIncome == null)
            {
                throw new Exception("Income does not exist");
            };
            var res = new IncomeResponseModel
            {
                Id = updatedIncome.Id,
                Amount = updatedIncome.Amount,
                Description = updatedIncome.Description,
                IncomeDate = updatedIncome.IncomeDate,
                Remarks = updatedIncome.Remarks
            };
            return res;

        }
    }
}
