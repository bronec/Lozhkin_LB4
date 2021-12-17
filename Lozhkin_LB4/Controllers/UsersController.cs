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
        public IActionResult Add([FromBody]UserModel user)
        {
            database.AddUser(user);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Remove(int id)
        {
            database.RemoveUser(id);
            return Ok();
        }

        [HttpPost]
        public IActionResult Modify([FromBody] ModifyRequestModel<UserModel> modifyRequest)
        {
            database.EditUser(modifyRequest.Id, modifyRequest.Entity);
            return Ok();
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var user = database.GetUserById(id);

            if(user == null)
            {
                return new JsonResult(new ErrorModel("No user found by that id"));
            }

            return new JsonResult(user);
        }
    }
}
