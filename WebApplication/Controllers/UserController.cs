using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Common.Dtos;
using WebApplication.Common.Models;
using WebApplication.Services.Interfaces;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("api/v1/user")]
    public class UserController : BaseController<UserController>
    {
        private readonly IUserServices _userServices;
        public UserController(IUserServices userServices, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _userServices = userServices;
        }

        [HttpGet]
        public ActionResult GetUserByUserId(int userId)
        {
            var records = _userServices.GetUserByUserId(userId);

            if (records != null)
            {
                return Ok(records);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpGet("All")]
        public ActionResult GetAllUser()
        {
            var records = _userServices.GetAllUser();

            if (records != null)
            {
                return Ok(records);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost("Add")]
        public ActionResult SaveUser([FromBody] UserDto userDto)
        {

            var user = new UserModal
            {
                UserId = userDto.UserId,
                CodeId = userDto.CodeId,
                Age = userDto.Age,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Password = userDto.Password,
                UserName = userDto.UserName,
                UserRole = userDto.UserRole
            };

            var result = _userServices.SaveUser(user);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPut("Edit")]
        public ActionResult EditUser([FromBody] UserDto userDto)
        {

            var user = new UserModal
            {
                UserId = userDto.UserId,
                CodeId = userDto.CodeId,
                Age = userDto.Age,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Password = userDto.Password,
                UserName = userDto.UserName,
                UserRole = userDto.UserRole
            };

            var result = _userServices.EditUser(user);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpDelete]
        public ActionResult DeleteUserByUserId(int userId)
        {
            var records = _userServices.DeleteUserByUserId(userId);

            if (records != null)
            {
                return Ok(records);
            }
            else
            {
                return NotFound();
            }

        }

    }
}
