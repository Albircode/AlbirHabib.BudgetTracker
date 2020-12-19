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
    public class ExpenditureRepository : EFRepository<Expenditure>, IExpenditureRepository
    {
        private readonly UserDbcontext _dbContext;
        public ExpenditureRepository(UserDbcontext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Expenditure>> GetExpenditureByUser(int UserId)
        {
            var expenditures = await _dbContext.Expenditures.Where(e => e.UserId == UserId).Select(e => new Expenditure
            {
                Id = e.Id,
                Amount = e.Amount,
                Description = e.Description,
                ExpDate = e.ExpDate,
                Remarks = e.Remarks
          
            }).ToListAsync();
            return expenditures;
        }
    }
}
