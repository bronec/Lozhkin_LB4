using Lozhkin_LB4.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Lozhkin_LB4.Controllers
{
    public class UsersController : Controller
    {
        private TextFileDatabase database = new TextFileDatabase();

        [HttpPost]
        public IActionResult Add([FromBody]UsersModel users)
        {
            database.AddUsers(users);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Remove(int id)
        {
            database.RemoveUsers(id);
            return Ok();
        }

        [HttpPost]
        public IActionResult Modify([FromBody] ModifyRequestModel<UsersModel> modifyRequest)
        {
            database.EditUsers(modifyRequest.Id, modifyRequest.Entity);
            return Ok();
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var users = database.GetUsersId(id);

            if(users == null)
            {
                return new JsonResult(new ErrorModel("No users found by that id"));
            }

            return new JsonResult(users);
        }
    }
}
