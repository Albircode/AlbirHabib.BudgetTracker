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
    public class ExpenditurService : IExpenditureService
    {
        private readonly IExpenditureRepository _expenditureRepository;

        public ExpenditurService( IExpenditureRepository expenditureRepository)
        {
          _expenditureRepository = expenditureRepository;
        }
        public async Task<ExpenditureResponseModel> AddExpediture(ExpenditureRequestModel model)
        {
            var expenditure = new Expenditure
            {
                UserId = model.UserId,
                Amount = model.Amount,
                Description = model.Description,
                ExpDate = model.ExpDate,
                Remarks = model.Remarks
            };
            var createdExpenditure = await _expenditureRepository.AddAsync(expenditure);
            var res = new ExpenditureResponseModel
            {
                Id = createdExpenditure.Id,
                Amount = createdExpenditure.Amount,
                Description = createdExpenditure.Description,
                ExpDate = createdExpenditure.ExpDate,
                Remarks = createdExpenditure.Remarks
            };
            return res;
        }

        public async Task<IEnumerable<ExpenditureResponseModel>> GetExpendituresByUserId(int id)
        {
            var expenditures = await _expenditureRepository.GetExpenditureByUser(id);
            var res = new List<ExpenditureResponseModel>();
            foreach (var expediture in expenditures)
            {
                res.Add(
                    new ExpenditureResponseModel
                    {
                        Amount =expediture.Amount,
                        Description = expediture.Description,
                        ExpDate = expediture.ExpDate,
                        Remarks = expediture.Remarks
                    }
                    ) ;
            }
            return res;
        }

        public async Task RemoveExpediture(int id)
        {
            var expenditure = await _expenditureRepository.GetByIdAsync(id);
            await _expenditureRepository.DeleteAsync(expenditure);
        }

        public async Task<ExpenditureResponseModel> UpdateExpediture(ExpenditureRequestModel model, int id)
        {
            var expendituretobeUpdated = await _expenditureRepository.GetByIdAsync(id);

            expendituretobeUpdated.Amount = model.Amount;
            expendituretobeUpdated.Description = model.Description;
            expendituretobeUpdated.ExpDate = model.ExpDate;
            expendituretobeUpdated.Remarks = model.Remarks;
           
            var updatedExpenditure = await _expenditureRepository.UpdateAsync(expendituretobeUpdated);
            var res = new ExpenditureResponseModel
            {
                Id = updatedExpenditure.Id,
                Amount = updatedExpenditure.Amount,
                Description = updatedExpenditure.Description,
                ExpDate = updatedExpenditure.ExpDate,
                Remarks = updatedExpenditure.Remarks
            };
            return res;
        }
    }
}
