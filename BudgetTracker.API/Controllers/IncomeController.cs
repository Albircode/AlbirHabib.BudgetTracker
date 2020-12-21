using BudgetTracker.Core.models.Request;
using BudgetTracker.Core.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomeController : ControllerBase
    {
        private readonly IIncomeService _incomeService;

        public IncomeController(IIncomeService incomeService)
        {
            _incomeService = incomeService;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetIncomes(int id)
        {
            var incomes = await _incomeService.GetIncomeByUserId(id);

            return Ok(incomes);
        }
        [Route("add")]
        [HttpPost]
        public async Task<IActionResult> AddIncome([FromBody] IncomeRequestModel incomeRequestModel)
        {
            await _incomeService.AddIncome(incomeRequestModel);
            return Ok();
        }
        [HttpPut]
        [Route("update/{id:int}")]

        public async Task<IActionResult> UpdateIncome([FromBody] IncomeRequestModel incomeRequestModel, int id)
        {
            await _incomeService.UpdateIncome(incomeRequestModel, id);
            return Ok();
        }
        [HttpDelete]
        [Route("delete/{id:int}")]

        public async Task<ActionResult> DeleteIncome(int id)
        {
            await _incomeService.RemoveExpediture(id);
            return Ok();
        }
    }
}
