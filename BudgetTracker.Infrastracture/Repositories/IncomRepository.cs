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
    public class IncomeRepository : EFRepository<Income>, IIncomeRepository
    {
        private readonly UserDbcontext _dbContext;
        public IncomeRepository(UserDbcontext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Income>> GetIncomeByUser(int UserId)
        {
            var incomes =await _dbContext.Incomes.Where(i => i.UserId == UserId).Select(i => new Income
            {
                Id = i.Id,
                Amount = i.Amount,
                Description = i.Description,
                Remarks = i.Remarks
            }).ToListAsync();
            return incomes;
        }
    }
}
