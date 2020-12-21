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
    public class ExpendtureController : ControllerBase
    {
        private readonly IExpenditureService _expendituresService;

        public ExpendtureController(IExpenditureService expendituresService)
        {
            _expendituresService = expendituresService;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Expenditures(int id)
        {
            var expenditures = await _expendituresService.GetExpendituresByUserId(id);

            return Ok(expenditures);
        }
        [Route("add")]
        [HttpPost]
        public async Task<IActionResult> AddExpenditure([FromBody] ExpenditureRequestModel expenditureRequestModel)
        {
            await _expendituresService.AddExpediture(expenditureRequestModel);
            return Ok();
        }
        [HttpPut]
        [Route("update/{id:int}")]
        
        public async Task<IActionResult> UpdateExpenditure([FromBody] ExpenditureRequestModel expenditureRequestModel,int id)
        {
            await _expendituresService.UpdateExpediture(expenditureRequestModel, id);
            return Ok();
        }
        [HttpDelete]
        [Route("delete/{id:int}")]

        public async Task<ActionResult> DeleteExpenditure(int id)
        {
            await _expendituresService.RemoveExpediture(id);
            return Ok();
        }
    }
}
