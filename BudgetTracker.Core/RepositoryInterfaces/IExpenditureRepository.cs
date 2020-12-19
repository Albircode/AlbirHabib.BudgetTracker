using BudgetTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Core.RepositoryInterfaces
{
   public interface IExpenditureRepository : IAsyncRepository<Expenditure>
    {
        Task<IEnumerable<Expenditure>> GetExpenditureByUser(int UserId);
    }
}
