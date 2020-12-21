using BudgetTracker.Core.models.Request;
using BudgetTracker.Core.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BudgetTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: api/user
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersasync();
            return Ok(users);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Detail(int id)
        {
            var user = await _userService.GetUserById(id);
            return Ok(user);
        }
        [HttpDelete ("delete/{id:int}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUser(id);
            return Ok();
        }
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddUser([FromBody] UserRequestModel model)
        {
            var user = await _userService.AddUser(model);
            return Ok(user);
        }
        [HttpPut]
        [Route("update/{id:int}")]
        public async Task<ActionResult> UpdateUser([FromBody] UserRequestModel model, int id)
        {
            await _userService.UpdateUser(model, id);
            return Ok();
        }

    }
}
