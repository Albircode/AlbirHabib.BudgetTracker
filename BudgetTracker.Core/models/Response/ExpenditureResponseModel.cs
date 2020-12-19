﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetTracker.Core.models.Response
{
   public class ExpenditureResponseModel
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public string Description { get; set; }

        public DateTime? ExpDate { get; set; }

        public string Remarks { get; set; }
    }
}
