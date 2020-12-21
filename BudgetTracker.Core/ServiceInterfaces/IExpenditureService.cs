using BudgetTracker.Core.models.Request;
using BudgetTracker.Core.models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Core.ServiceInterfaces
{
   public interface IExpenditureService
    {
        Task<IEnumerable<ExpenditureResponseModel>> GetExpendituresByUserId(int id);
        Task<ExpenditureResponseModel> AddExpediture(ExpenditureRequestModel model);
        Task<ExpenditureResponseModel> UpdateExpediture(ExpenditureRequestModel model, int id);
        Task RemoveExpediture(int id);


    }
}
