using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Bookstore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUserBL userBL;
        public UserController(IUserBL userBL)
        {
            this.userBL = userBL;
        }
        [HttpPost("Register")]
        public IActionResult userRegister(UserModel usermodel)
        {
            try
            {
                var result = userBL.userRegistration(usermodel);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Registration successfull", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Unsuccessfull" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
