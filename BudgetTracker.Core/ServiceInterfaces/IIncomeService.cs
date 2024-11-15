﻿using BudgetTracker.Core.models.Request;
using BudgetTracker.Core.models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Core.ServiceInterfaces
{
   public interface IIncomeService
    {
        Task<IEnumerable<IncomeResponseModel>> GetIncomeByUserId(int id);
        Task<IncomeResponseModel> AddIncome(IncomeRequestModel model);
        Task<IncomeResponseModel> UpdateIncome(IncomeRequestModel model, int id);
        Task RemoveExpediture(int id);
    }
}
