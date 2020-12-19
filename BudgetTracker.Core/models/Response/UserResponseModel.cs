using BudgetTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetTracker.Core.models.Response
{
   public class UserResponseModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public decimal  TotalIncomes { get; set; }
        public decimal TotalExpenditures { get; set; }
        public ICollection<Income> Incomes { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
