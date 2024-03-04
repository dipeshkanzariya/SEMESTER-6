using API_Demo.BAL;
using API_Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Demo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        #region Get all users
        [HttpGet]
        public IActionResult Get()
        {
            User_BALBase bal = new User_BALBase();
            List<UserModel> users = bal.PR_SELECT_ALL_USER();
            // Make the Response in key Value pair
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if(users.Count > 0 && users != null)
            {
                response.Add("status", true);
                response.Add("message", "Data Found.");
                response.Add("data", users);
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data not Found.");
                response.Add("data", null);
                return NotFound(response);
            }
        }

        #endregion

        #region Get user by id

        [HttpGet("{UserID}")]

        public IActionResult Get(int UserID) 
        {
            User_BALBase bal = new User_BALBase();
            UserModel user = bal.PR_SELECT_BY_PK_USER(UserID);
            // Make the response in key value pair
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if(user.UserID != 0)
            {
                response.Add("status", true);
                response.Add("messsage", "Data Found.");
                response.Add("data", user);
                return Ok(response);
            }
            else
            {
                response.Add("staus", false);
                response.Add("message", "Data not Found.");
                response.Add("data", null);
                return NotFound(response);
            }
        }

        #endregion

        #region Insert User
        [HttpPost]
        public IActionResult Post([FromForm] UserModel userModel)
        {
            User_BALBase balUser = new User_BALBase();
            bool IsSuccess = balUser.PR_INSERT_USER(userModel);

            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (IsSuccess)
            {
                response.Add("status", true);
                response.Add("message", "Data Inserted SuccessFully");
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Some Error has been occured");
                return Ok(response);
            }
        }

        #endregion

        #region Update user
        [HttpPut]
        public IActionResult Put(int UserID, [FromForm] UserModel userModel)
        {
            User_BALBase balUser = new User_BALBase();
            userModel.UserID = UserID;
            bool IsSuccess = balUser.PR_UPDATE_USER(UserID, userModel);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (IsSuccess)
            {
                response.Add("status", true);
                response.Add("message", "Data Updated SuccessFully");
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Some Error has been occured");
                return Ok(response);
            }
        }

        #endregion

        #region Delete User
        [HttpDelete("{UserID}")]
        public IActionResult Delete(int UserID)
        {
            User_BALBase balUser = new User_BALBase();
            bool IsSuccess = balUser.PR_DELETE_USER(UserID);

            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if(IsSuccess)
            {
                response.Add("status", true);
                response.Add("message", "Data Deleted SuccessFully");
                return Ok(response);
            }
            else
            {
                response.Add ("status", false);
                response.Add("message", "Some Error has been occured");
                return Ok(response);
            }
        }

        #endregion
    }
}
