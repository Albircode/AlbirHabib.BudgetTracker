using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetTracker.Core.models.Request
{
   public class IncomeRequestModel
    {
        public int? UserId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime? IncomeDate { get; set; }
        public string Remarks { get; set; }
    }
}
